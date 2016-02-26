namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlcoholProducts", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlcoholProducts", "name");
        }
    }
}
