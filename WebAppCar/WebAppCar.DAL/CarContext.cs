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
        {}
        public CarContext(string connectionString):base(connectionString)
        { }
    }
}
