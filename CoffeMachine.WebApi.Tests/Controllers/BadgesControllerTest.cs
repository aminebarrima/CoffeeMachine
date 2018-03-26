using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeMachine.WebApi.Controllers;
using CoffeeMachine.Models;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Linq;

namespace CoffeMachine.WebApi.Tests.Controllers
{
    [TestClass]
    public class BadgesControllerTest : BaseTests<Badge>
    {
        BoissonsController objController;
        List<Badge> listBadge;

        [TestInitialize]
        public void Initialize()
        {
            base.Initialize();
            listBadge = new List<Badge>
            {
               new Badge {keyBadge="Badge 1"},
                new Badge {keyBadge="Badge 2"},
                new Badge {keyBadge="Badge 3"},
            };


        }
        [TestMethod]
        public void Badges_GetBadge_Should_Return_ListBadgesWithSameLenght()
        {
            //Arrange
            moqRepository.Setup(g => g.GetAll(null)).Returns(listBadge).Verifiable();
            moqUnitOfWork.Setup(x => x.Repository<Badge>()).Returns(moqRepository.Object);

            var controller = new BadgesController(moqUnitOfWork.Object);

            // Act
            var contentResult = controller.GetBadge() as OkNegotiatedContentResult<List<Badge>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count());
        }
    }
}
