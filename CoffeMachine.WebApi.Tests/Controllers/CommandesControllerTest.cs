using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeMachine.WebApi.Controllers;
using CoffeeMachine.Models;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Linq;
using System;

namespace CoffeMachine.WebApi.Tests.Controllers
{
    [TestClass]
    public class CommandesControllerTest : BaseTests<Commande>
    {
        CommandesController objController;
        List<Commande> listCommandes;


        [TestInitialize]
        public void Initialize()
        {
            base.Initialize();
            listCommandes = new List<Commande>
            {
               new Commande{withMug=true,memoeryFlage=true,badgeId=1,sucre=1,commandeId=1,badge=new Badge {badgeId=1 } },
            //new Commande{withMug=true,memoeryFlage=true,badgeId=1,dateCommande=DateTime.Now },
            };


        }
        [TestMethod]
        public void Commandess_getMemoeryCommandeByBadge_Should_Return_oneComande()
        {
            //Arrange
            moqRepository.Setup(g => g.GetAll(null)).Returns(listCommandes).Verifiable();
            moqUnitOfWork.Setup(x => x.Repository<Commande>()).Returns(moqRepository.Object);

            var controller = new CommandesController(moqUnitOfWork.Object);

            // Act
            var contentResult = controller.getMemoeryCommandeByBadge(1) as OkNegotiatedContentResult<Commande>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(1, contentResult.Content.Count());
        }
    }
}
