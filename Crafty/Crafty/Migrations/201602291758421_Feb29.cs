namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feb29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        boxName = c.String(),
                        boxPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AlcoholProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Box_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Boxes", t => t.Box_ID)
                .Index(t => t.Box_ID);
            
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
                        userID = c.String(),
                        sum = c.Int(nullable: false),
                        isSubscribed = c.Boolean(nullable: false),
                        box_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Boxes", t => t.box_ID)
                .Index(t => t.box_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "box_ID", "dbo.Boxes");
            DropForeignKey("dbo.AlcoholProducts", "Box_ID", "dbo.Boxes");
            DropIndex("dbo.Surveys", new[] { "box_ID" });
            DropIndex("dbo.AlcoholProducts", new[] { "Box_ID" });
            DropTable("dbo.Surveys");
            DropTable("dbo.AlcoholProducts");
            DropTable("dbo.Boxes");
        }
    }
}
