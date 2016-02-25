namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Surveys", "userID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Surveys", "userID", c => c.Int(nullable: false));
        }
    }
}
