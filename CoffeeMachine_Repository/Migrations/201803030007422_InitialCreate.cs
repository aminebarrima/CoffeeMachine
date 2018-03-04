namespace CoffeeMachine.GetWay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Badge",
                c => new
                    {
                        badgeId = c.Int(nullable: false, identity: true),
                        keyBadge = c.String(),
                    })
                .PrimaryKey(t => t.badgeId);
            
            CreateTable(
                "dbo.Commande",
                c => new
                    {
                        commandeId = c.Int(nullable: false, identity: true),
                        withMug = c.Boolean(nullable: false),
                        dateCommande = c.DateTime(nullable: false),
                        badgeId = c.Int(nullable: false),
                        boissonId = c.Int(nullable: false),
                        memoeryFlage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.commandeId)
                .ForeignKey("dbo.Badge", t => t.badgeId, cascadeDelete: true)
                .ForeignKey("dbo.Boisson", t => t.boissonId, cascadeDelete: true)
                .Index(t => t.badgeId)
                .Index(t => t.boissonId);
            
            CreateTable(
                "dbo.Boisson",
                c => new
                    {
                        boissonId = c.Int(nullable: false, identity: true),
                        typeBoisson = c.String(),
                        sucre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.boissonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commande", "boissonId", "dbo.Boisson");
            DropForeignKey("dbo.Commande", "badgeId", "dbo.Badge");
            DropIndex("dbo.Commande", new[] { "boissonId" });
            DropIndex("dbo.Commande", new[] { "badgeId" });
            DropTable("dbo.Boisson");
            DropTable("dbo.Commande");
            DropTable("dbo.Badge");
        }
    }
}
