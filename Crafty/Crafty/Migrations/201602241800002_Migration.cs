namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        question1 = c.Int(nullable: false),
                        question2 = c.Int(nullable: false),
                        question3 = c.Int(nullable: false),
                        question4 = c.Int(nullable: false),
                        question5 = c.Int(nullable: false),
                        question6 = c.Int(nullable: false),
                        question7 = c.Int(nullable: false),
                        question8 = c.Int(nullable: false),
                        sum = c.Int(nullable: false),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RegisteredUsers", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        subscriptionCost = c.Int(nullable: false),
                        totalSubscriptionCost = c.Int(nullable: false),
                        productDemographic = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "user_ID", "dbo.RegisteredUsers");
            DropIndex("dbo.Surveys", new[] { "user_ID" });
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Surveys");
        }
    }
}
