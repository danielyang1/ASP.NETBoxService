namespace Crafty.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Crafty.Models.RegisteredUserDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Crafty.Models.RegisteredUserDBContext";
        }

        protected override void Seed(Crafty.Models.RegisteredUserDBContext context)
        {
           // This method will be called after migrating to the latest version.

           // You can use the DbSet<T>.AddOrUpdate() helper extension method
           // to avoid creating duplicate seed data.E.g.

              context.RegisteredUsers.AddOrUpdate(
                p => p.name,
                new RegisteredUser { name = "Eazy=E", address = "Compton", subscriptionCost = 500, totalSubscriptionCost = 1000, productDemographic = "Wine"},
                new RegisteredUser { name = "test", address = "333 Plankinton", subscriptionCost = 800, totalSubscriptionCost = 2000, productDemographic = "Wine"}
              );

        }
    }
}
