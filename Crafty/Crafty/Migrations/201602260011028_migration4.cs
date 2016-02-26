namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Boxes", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boxes", "test", c => c.Double(nullable: false));
        }
    }
}
