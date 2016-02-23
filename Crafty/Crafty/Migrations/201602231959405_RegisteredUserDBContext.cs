namespace Crafty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisteredUserDBContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredUsers", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisteredUsers", "name");
        }
    }
}
