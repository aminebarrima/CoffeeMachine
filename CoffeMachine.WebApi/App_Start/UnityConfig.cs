using CoffeeMachine.GetWay.Infrastructure;
using System.Web.Http;
using Unity;
using System.Web.Mvc;
using CoffeeMachine.GetWay;

namespace CoffeMachine.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<CoffeeMachineDbContext, CoffeeMachineDbContext>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}