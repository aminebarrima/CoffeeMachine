namespace CoffeeMachine.GetWay.Migrations
{
    using Infrastructure;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CoffeeMachine.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeeMachine.GetWay.CoffeeMachineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CoffeeMachine.GetWay.CoffeeMachineDbContext";
        }

        protected override void Seed(CoffeeMachine.GetWay.CoffeeMachineDbContext context)
        {
            IUnitOfWork _unitOfWork = new UnitOfWork(context);

            var Boisson = new List<Boisson>
            {
               new Boisson {typeBoisson="thé" },
               new Boisson {typeBoisson="café"  },
               new Boisson {typeBoisson="chocolat"  }

            };

            var Badge = new List<Badge>
            {
                new Badge {keyBadge="Badge 1"},
                new Badge {keyBadge="Badge 2"},
                new Badge {keyBadge="Badge 3"},
            };

           
                var boissons = _unitOfWork.Repository<Boisson>();
                Boisson.ForEach(s => boissons.Add(s));

                var badges = _unitOfWork.Repository<Badge>();
                Badge.ForEach(s => badges.Add(s));


                _unitOfWork.SaveChanges();

           
        }
    }
}
