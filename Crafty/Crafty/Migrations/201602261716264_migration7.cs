namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        numberOfTotalAccounts = c.Double(nullable: false),
                        numberOfPayingAccounts = c.Double(nullable: false),
                        numberOfHardLiquorAccounts = c.Double(nullable: false),
                        numberOfBeerAccounts = c.Double(nullable: false),
                        numberOfWineAccounts = c.Double(nullable: false),
                        monthlyRevenue = c.Double(nullable: false),
                        percentHardLiqourAccounts = c.Double(nullable: false),
                        percentBeerAccounts = c.Double(nullable: false),
                        percentWineAccounts = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminModels");
        }
    }
}
