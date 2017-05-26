using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCar.BL;
using WebAppCar.BL.DTO;
using WebAppCar.ViewModel;

namespace WebAppCar.Controllers
{
    public class HomeController : Controller
    {
        private IService serv;
        public HomeController()
        {
            this.serv = new Service();
        }
        // GET: Home
        public ActionResult Index()
        {

            IEnumerable<CarDTO> col = serv.GetAllCars();
            Mapper.Initialize(cfg => cfg.CreateMap<CarDTO, CarViewModel>());
            var values =
                Mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(col);
            return View(values);


        }
        public ActionResult Country()
        {
            IEnumerable<CountryDTO> contr = serv.GetAllCountries();
            Mapper.Initialize(cfg => cfg.CreateMap<CountryDTO, CountryViewModel>());
            var val =
                Mapper.Map<IEnumerable<CountryDTO>, List<CountryViewModel>>(contr);
            return View(val);
        }
    }
}