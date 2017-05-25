using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCar.DAL.Entities;
using WebAppCar.DAL.Interfaces;

namespace WebAppCar.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork,IDisposable
    {
        private CarContext db;
        private CarRepository _carRepository;
        private CountryRepository _countryRepository;
        public EFUnitOfWork()
        {
            this.db = new CarContext();
        }
        public EFUnitOfWork(string connectionString)
        {
            this.db = new CarContext(connectionString);
        }
        public IRepository<Car> Cars
        {
            get
            {
                if(_carRepository==null)
                {
                    _carRepository = new CarRepository(db);
                }
                return _carRepository;
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                if(_countryRepository==null)
                {
                    _countryRepository = new CountryRepository(db);
                }
                return _countryRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
