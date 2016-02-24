namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Surveys", "user_ID", "dbo.RegisteredUsers");
            DropIndex("dbo.Surveys", new[] { "user_ID" });
            AddColumn("dbo.Surveys", "userID", c => c.Int(nullable: false));
            AddColumn("dbo.Surveys", "productDemographic", c => c.String());
            DropColumn("dbo.Surveys", "user_ID");
            DropColumn("dbo.RegisteredUsers", "productDemographic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisteredUsers", "productDemographic", c => c.String());
            AddColumn("dbo.Surveys", "user_ID", c => c.Int());
            DropColumn("dbo.Surveys", "productDemographic");
            DropColumn("dbo.Surveys", "userID");
            CreateIndex("dbo.Surveys", "user_ID");
            AddForeignKey("dbo.Surveys", "user_ID", "dbo.RegisteredUsers", "ID");
        }
    }
}
