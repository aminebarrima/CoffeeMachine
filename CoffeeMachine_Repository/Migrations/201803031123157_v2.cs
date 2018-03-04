namespace CoffeeMachine.GetWay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Commande", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commande", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
