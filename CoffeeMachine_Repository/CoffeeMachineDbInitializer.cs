using CoffeeMachine.GetWay.Infrastructure;
using CoffeeMachine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.GetWay
{
    public class CoffeeMachineDbInitializer :CreateDatabaseIfNotExists <CoffeeMachineDbContext>
    {





        protected override void Seed(CoffeeMachineDbContext context)
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
                new Badge {keyBadge="Badge 1"},
                new Badge {keyBadge="Badge 2"},
                new Badge {keyBadge="Badge 3"},
            };                

            try
            {
                var boissons = _unitOfWork.Repository<Boisson>();
                Boisson.ForEach(s => boissons.Add(s));

                var badges = _unitOfWork.Repository<Badge>();
                Badge.ForEach(s => badges.Add(s));
                           

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

 
