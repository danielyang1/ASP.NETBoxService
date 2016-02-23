namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productDemographic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredUsers", "productDemographic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisteredUsers", "productDemographic");
        }
    }
}
