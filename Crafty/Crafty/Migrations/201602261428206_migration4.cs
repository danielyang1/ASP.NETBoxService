namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AlcoholProducts", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlcoholProducts", "name", c => c.String());
        }
    }
}
