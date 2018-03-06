namespace CoffeeMachine.GetWay.Migrations
{
    using CoffeeMachine.Models;
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed  class Configuration : DbMigrationsConfiguration<CoffeeMachine.GetWay.CoffeeMachineDbContext>
    {

        
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CoffeeMachine_Repository.CoffeeMachineDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CoffeeMachine.GetWay.CoffeeMachineDbContext context)
        {
            
            base.Seed(context);
#if DEBUG
        IUnitOfWork _unitOfWork = new UnitOfWork(context);


        var Boisson = new List<Boisson>
            {
                new Boisson {typeBoisson="thé" },
               new Boisson {typeBoisson="café"  },
            new Boisson {typeBoisson="chocolat"  }

            };
           

            var Badge = new List<Badge>
            {

                new Badge {keyBadge="1234"},

            };

          


            var commande = new List<Commande>
            {

                new Commande {withMug=false,memoeryFlage=true,sucre=2,dateCommande=DateTime.Now, badgeId=1,boissonId=1 },

            };

            




            try
            {
                var boissons = _unitOfWork.Repository<Boisson>();
                Boisson.ForEach(s => boissons.Add(s));

                var badges = _unitOfWork.Repository<Badge>();
                Badge.ForEach(s =>badges.Add(s));


                var commandes = _unitOfWork.Repository<Commande>();
                commande.ForEach(s => commandes.Add(s));

                _unitOfWork.SaveChanges();
                 
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
#endif
    }
}

