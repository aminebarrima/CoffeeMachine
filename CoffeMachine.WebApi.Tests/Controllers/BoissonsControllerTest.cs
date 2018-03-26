using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeMachine.WebApi.Controllers;
using CoffeeMachine.Models;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Linq;

namespace CoffeMachine.WebApi.Tests.Controllers
{
    [TestClass]
    public class BoissonsControllerTest : BaseTests<Boisson>
    {
        BoissonsController objController;
        List<Boisson> listBoisson;


        [TestInitialize]
        public void Initialize()
        {
            base.Initialize();
            listBoisson = new List<Boisson>
            {
               new Boisson {typeBoisson="thé" },
               new Boisson {typeBoisson="café"  },
               new Boisson {typeBoisson="chocolat"  }

            };


        }
        [TestMethod]
        public void GBoissons_GeBoisson_Should_Return_ListBoissonsWithSameLenght()
        {
            //Arrange
            moqRepository.Setup(g => g.GetAll(null)).Returns(listBoisson).Verifiable();
            moqUnitOfWork.Setup(x => x.Repository<Boisson>()).Returns(moqRepository.Object);

            var controller = new BoissonsController(moqUnitOfWork.Object);

            // Act
            var contentResult = controller.GetBoisson() as OkNegotiatedContentResult<List<Boisson>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count());
        }
     

    }
}
