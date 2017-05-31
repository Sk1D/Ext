using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAppCar.DAL.Entities;
using WebAppCar.DAL.Interfaces;

namespace WebAppCar.DAL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private CarContext db;
        public CarRepository(CarContext context)
        {
            this.db = context;
        }
        public void Create(Car value)
        {
            db.Cars.Add(value);
        }

        public void Delete(int id)
        {
            var value = db.Cars.Find(id);
            if(value!=null)
            {
                db.Cars.Remove(value);
            }
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return db.Cars.Where(predicate).ToList();
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
                return db.Cars;
        }

        public IEnumerable<Car> Include()
        {
            return db.Cars.Include(t => t.Countries).ToList();
        }

        public void Insert(int SourceId, int DestId)
        {
            Car dest = db.Cars.Find(DestId);
            Country sourc = db.Countries.Find(SourceId);
            if (dest != null && sourc != null)
            {
                dest.Countries.Add(sourc);
            }
        }

        public void Update(Car value)
        {
            db.Entry(value).State = EntityState.Modified;
        }
    }
}
