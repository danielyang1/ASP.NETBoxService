namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration91 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Surveys", "productDemographic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surveys", "productDemographic", c => c.String());
        }
    }
}
