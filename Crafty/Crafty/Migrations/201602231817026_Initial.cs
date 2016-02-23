namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        q1 = c.Int(nullable: false),
                        q2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SurveyModel");
        }
    }
}
