using CoffeeMachine.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace CoffeeMachine.GetWay
{
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext()
            : base("CoffeeMachine")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<CoffeeMachineDbContext>(new CoffeeMachineDbInitializer());
          
        }

        public DbSet<Boisson> Boisson { get; set; }
        public DbSet<Badge> Badge { get; set; }
        public DbSet<Commande> Commande { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
       
    }
}
