using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCar.BL.DTO;

namespace WebAppCar.BL
{
    public interface IService
    {
        IEnumerable<CarDTO> GetAllCars();
        void AddCar(CarDTO carDto);
        void DelCar(int? id);
        IEnumerable<CountryDTO> GetAllCountries();
        void AddCountry(CountryDTO countryDto);
        void DelCountry(int? id);
        void Dispose();
        CarDTO GetCarById(int? id);
        CountryDTO GetCountryById(int? Id);
    }
}
