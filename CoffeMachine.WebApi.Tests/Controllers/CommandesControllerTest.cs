using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMachine.GetWay.Infrastructure;
using CoffeMachine.WebApi.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using CoffeeMachine.GetWay;

namespace CoffeMachine.WebApi.Tests.Controllers
{
    [TestClass]
    public class CommandesControllerTest
    {
       private readonly IUnitOfWork _unitOfWork;
        public CommandesControllerTest()
        {
            CoffeeMachineDbContext dbcntx = new CoffeeMachineDbContext();
             _unitOfWork =new UnitOfWork(dbcntx);
        }


        [TestMethod]
        public void TestgetMemoeryCommandeByBadge()
        {
            CommandesController controller = new CommandesController(_unitOfWork);
            
            // Agir
            //ViewResult result = controller.Index() as ViewResult;
            var result = controller.getMemoeryCommandeByBadge(1)  ;
            // Affirmer
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
