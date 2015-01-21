namespace Restaurant.Domain.Migrations
{
    using Restaurant.Domain.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurant.Domain.DataBaseModel._RestaurantDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Restaurant.Domain.DataBaseModel._RestaurantDb";
        }

        protected override void Seed(Restaurant.Domain.DataBaseModel._RestaurantDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            

            int idRest = context.Restaurants.Where(x => x.Name == "2").Select(x => x.Id).First();
            for(int i = 0; i < 100; i++)
            {
                context.Reviewes.Add(
                        new Reviewe() { ReviewerName = i.ToString(), 
                                        ReviewerMessage="This is some message from " + i.ToString(),
                                        RestaurantInfo = context.Restaurants.Where(x => x.Name == "2").First()
                        });
            }
        }
    }
}
