using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCar.DAL.Entities;

namespace WebAppCar.DAL
{
    public class CarContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Country> Countries { get; set; }
        public CarContext():base("MyDefaultConnection")
        {
            Database.SetInitializer<CarContext>(new DropCreateDatabaseAlways());
        }
        public CarContext(string connectionString):base(connectionString)
        {
            Database.SetInitializer<CarContext>(new DropCreateDatabaseAlways());
        }
        public void Seed(CarContext db)
        {
            Car car1 = new Car { Brand = "Toyota", Model = "IS300" };
            Car car2 = new Car { Brand = "BMW", Model = "E36" };
            Car car3 = new Car { Brand = "BMW", Model = "M3" };
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
        public class DropCreateDatabaseAlways : DropCreateDatabaseIfModelChanges<CarContext>
        {
            protected override void Seed(CarContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
        //public void FixEfProviderServicesProblem()
        //{
        //    //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
        //    //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
        //    //Make sure the provider assembly is available to the running application. 
        //    //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

        //    var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        //}
    }
}
