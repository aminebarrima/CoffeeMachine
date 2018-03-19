using CoffeeMachine.GetWay.Infrastructure;
using System.Web.Http;
using Unity;
using System.Web.Mvc;
using CoffeeMachine.GetWay;
using Unity.Injection;
using Microsoft.AspNet.Identity;
using CoffeMachine.WebApi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Data.Entity;
using CoffeMachine.WebApi.Controllers;

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
            //var accountInjectionConstructor = new InjectionConstructor(new IdentitySampleDbModelContext(configurationStore));
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(accountInjectionConstructor);
            //container.RegisterType<IRoleStore<IdentityRole>, RoleStore<IdentityRole>>(accountInjectionConstructor);
            // TODO: Register your types here
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<CoffeeMachineDbContext, CoffeeMachineDbContext>();
            //container.RegisterType<ApplicationUserManager, ApplicationUserManager>();
            //container.RegisterType<ISecureDataFormat<AuthenticationTicket>, ISecureDataFormat<AuthenticationTicket>>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            
        }
    }
}