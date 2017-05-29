using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using WebAppCar.BL;
using WebAppCar.BL.DTO;

using WebAppCar.ViewModel;


namespace WebAppCar.Controllers
{
    public class HomeController : Controller
    {
        private IService serv;
        public HomeController(IService service)
        {
            this.serv = service;
        }
        
        //public HomeController()
        //{
        //    this.serv = new Service();
        //}
        // GET: Home
        public ActionResult Index()
        {
            

            IEnumerable<CarDTO> col = serv.GetAllCars();
            Mapper.Initialize(cfg => cfg.CreateMap<CarDTO, CarViewModel>());
            var values =
                Mapper.Map<IEnumerable<CarDTO>, List<CarViewModel>>(col);
            return View(values);


        }
        public ActionResult Page2()
        {
            return View();
        }
        public ActionResult Country()
        {
            IEnumerable<CountryDTO> contr = serv.GetAllCountries();
            Mapper.Initialize(cfg => cfg.CreateMap<CountryDTO, CountryViewModel>());
            var val =
                Mapper.Map<IEnumerable<CountryDTO>, List<CountryViewModel>>(contr);
            return View(val);
        }
        [HttpGet]
        public ActionResult DeleteCar(int? id)
        {
            serv.DelCar(id.Value);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CreateCar(int? id)
        {
            if(id==null)
                return View();
            else
            {
                CarDTO value = serv.GetCarById(id.Value);
                Mapper.Initialize(cfg => cfg.CreateMap<CarDTO, CarViewModel>());
                var result =
                    Mapper.Map<CarDTO, CarViewModel>(value);
                return View(result);
            }
        }
        [HttpPost]
        public ActionResult CreateCar(CarViewModel car)
        {
            if(car.Model==null || car.Brand==null)
            {
                return View(car);
            }
            else 
            {
                try
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<CarViewModel, CarDTO>());
                    var val =
                        Mapper.Map<CarViewModel, CarDTO>(car);
                    serv.AddCar(val);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    throw new Exception("Error data automapper", e);
                }
            }
 
        }
    }
}