namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdminModels", "numberOfTotalAccounts", c => c.Double());
            AlterColumn("dbo.AdminModels", "numberOfPayingAccounts", c => c.Double());
            AlterColumn("dbo.AdminModels", "numberOfHardLiquorAccounts", c => c.Double());
            AlterColumn("dbo.AdminModels", "numberOfBeerAccounts", c => c.Double());
            AlterColumn("dbo.AdminModels", "numberOfWineAccounts", c => c.Double());
            AlterColumn("dbo.AdminModels", "monthlyRevenue", c => c.Double());
            AlterColumn("dbo.AdminModels", "percentHardLiqourAccounts", c => c.Double());
            AlterColumn("dbo.AdminModels", "percentBeerAccounts", c => c.Double());
            AlterColumn("dbo.AdminModels", "percentWineAccounts", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdminModels", "percentWineAccounts", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "percentBeerAccounts", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "percentHardLiqourAccounts", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "monthlyRevenue", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "numberOfWineAccounts", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "numberOfBeerAccounts", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "numberOfHardLiquorAccounts", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "numberOfPayingAccounts", c => c.Double(nullable: false));
            AlterColumn("dbo.AdminModels", "numberOfTotalAccounts", c => c.Double(nullable: false));
        }
    }
}
