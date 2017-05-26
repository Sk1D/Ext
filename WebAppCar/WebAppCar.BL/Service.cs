using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCar.BL.DTO;
using WebAppCar.DAL;
using WebAppCar.DAL.Entities;
using WebAppCar.DAL.Interfaces;
using WebAppCar.DAL.Repositories;

namespace WebAppCar.BL
{
    public class Service : IService  //del EF + using WebAppCar.DAL.Repositories;
    {
        IUnitOfWork Database { get; set; }
        public Service(IUnitOfWork uow)
        {
            this.Database = uow;
        }
        public Service()
        {
            this.Database = new EFUnitOfWork();
        }
        public void AddCar(CarDTO carDto)
        {
            throw new NotImplementedException();
        }

        public void AddCountry(CountryDTO countryDto)
        {
            throw new NotImplementedException();
        }

        public void DelCar(int? id)
        {
            throw new NotImplementedException();
        }

        public void DelCountry(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<CarDTO> GetAllCars()
        {
            IEnumerable<Car> val = Database.Cars.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Car, CarDTO>());
            var result = Mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(val);
            return result;
        }

        public IEnumerable<CountryDTO> GetAllCountries()
        {
            IEnumerable<Country> val = Database.Countries.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
            var result = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(val);
            return result;
        }
    }
}
