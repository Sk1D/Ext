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
        //public Service()
        //{
        //    this.Database = new EFUnitOfWork();
        //}
        public void AddCar(CarDTO carDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CarDTO, Car>());
            Car _car = Mapper.Map<CarDTO, Car>(carDto);
            if (carDto.Id==0)
            {           
                Database.Cars.Create(_car);
            }
            else
            {
                Database.Cars.Update(_car);
            }
            Database.Save();
        }

        public void AddCountry(CountryDTO countryDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CountryDTO, Country>());
            Country _country = Mapper.Map<CountryDTO, Country>(countryDto);
            if(countryDto.Id==0)
            {
                Database.Countries.Create(_country);
            }
            else
            {
                Database.Countries.Update(_country);
            }
            Database.Save();
        }

        public void DelCar(int? id)
        {
            Database.Cars.Delete(id.Value);
            Database.Save();
        }

        public void DelCountry(int? id)
        {
            Database.Countries.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
        public CarDTO GetCarById(int? id)
        {
            Car item = Database.Cars.Find(x => x.Id == id.Value).First();
            Mapper.Initialize(cfg => cfg.CreateMap<Car, CarDTO>());
            var result = Mapper.Map<Car, CarDTO>(item);
            return result;
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

        public CountryDTO GetCountryById(int? Id)
        {
            Country country = Database.Countries.Find(x => x.Id == Id.Value).First();
            Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
            var result = Mapper.Map<Country, CountryDTO>(country);
            return result;
        }
        public IEnumerable<CountryCarDTO> GetAllRelations()
        {
            //IEnumerable<Car> val = Database.Cars.GetAll();
            IEnumerable<Car> resultCars= Database.Cars.Include();
            List<CountryCarDTO> relation = new List<CountryCarDTO>();
            foreach (Car c in resultCars)
            {
                
                foreach(Country t in c.Countries)
                {
                    relation.Add(
                        new CountryCarDTO
                        {
                            CarId=c.Id,
                            Model=c.Model,
                            Brand=c.Brand,
                            CountryId=t.Id,
                            Continent=t.Continent,
                            NameOfContry=t.NameOfContry
                        }
                        );
                }
            }
            return relation;
        }

        public void addCarToCountry(int idCar, int idCountry)
        {
            Database.Countries.Insert(idCar, idCountry);
            Database.Save();
        }

        public void addCountryToCar(int idCar, int idCountry)
        {
            Database.Cars.Insert(idCountry, idCar);
            Database.Save();
        }
    }
}
