namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boxes", "test", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boxes", "test");
        }
    }
}
