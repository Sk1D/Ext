namespace WebAppCar.DAL.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppCar.DAL.CarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAppCar.DAL.CarContext db)
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
            Car car1 = new Car { Brand = "Toyota", Model = "IS300" };
            Car car2 = new Car { Brand="BMW", Model="E36"};
            Car car3 = new Car { Brand = "BMW", Model = "M1" };
            db.Cars.AddRange(new List<Car> { car1, car2, car3 });
            db.SaveChanges();
            Country country1 = new Country { Continent = "Europe", NameOfContry = "Germany" };
            country1.Cars.Add(car2);
            country1.Cars.Add(car3);
            Country country2 = new Country { Continent = "Asia", NameOfContry = "Japan" };
            country2.Cars.Add(car1);
            db.Countries.Add(country1);
            db.Countries.Add(country2);
            db.SaveChanges();
        }
    }
}
