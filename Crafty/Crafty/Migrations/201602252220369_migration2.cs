namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlcoholProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Box_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Boxes", t => t.Box_ID)
                .Index(t => t.Box_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlcoholProducts", "Box_ID", "dbo.Boxes");
            DropIndex("dbo.AlcoholProducts", new[] { "Box_ID" });
            DropTable("dbo.AlcoholProducts");
        }
    }
}
