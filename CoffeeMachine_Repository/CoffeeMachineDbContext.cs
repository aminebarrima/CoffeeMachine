using CoffeeMachine.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace CoffeeMachine.GetWay
{
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext()
            : base("name=DbCoffeeMachine")
        {
           // Database.SetInitializer<CoffeeMachineDbContext>(new CoffeeMachineDbInitializer());
            Database.SetInitializer<CoffeeMachineDbContext>(null);

            this.Configuration.LazyLoadingEnabled = false;
           // this.Configuration.ProxyCreationEnabled = false;

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
