using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCar.DAL.Entities;
using WebAppCar.DAL.Interfaces;

namespace WebAppCar.DAL.Repositories
{
    class CountryRepository : IRepository<Country>
    {
        private CarContext db;
        public CountryRepository(CarContext context)
        {
            this.db = context;
        }
        public void Create(Country value)
        {
            db.Countries.Add(value);
        }

        public void Delete(int id)
        {
            var value = db.Countries.Find(id);
            if(value!=null)
            {
                db.Countries.Remove(value);
            }
        }

        public IEnumerable<Country> Find(Func<Country, bool> predicate)
        {
            return db.Countries.Where(predicate).ToList();
        }

        public Country Get(int id)
        {
            return db.Countries.Find(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Countries;
        }

        public void Update(Country value)
        {
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
