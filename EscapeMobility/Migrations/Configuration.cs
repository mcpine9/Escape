using EscapeMobility.Domain;

namespace EscapeMobility.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EscapeMobility.Infrastructure.CustomerDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EscapeMobility.Infrastructure.CustomerDb context)
        {
            context.Categories.AddOrUpdate(c => c.CategoryName,
                new Category() { CategoryDescription = "Hospital building.", CategoryName = "Hospitals" },
                new Category() { CategoryDescription = "Apartment building.", CategoryName = "Apartment" },
                new Category() { CategoryDescription = "Commercial building.", CategoryName = "Commercial" },
                new Category() { CategoryDescription = "Highschool building.", CategoryName = "High School" },
                new Category() { CategoryDescription = "University building.", CategoryName = "University" });
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
        }
    }
}
