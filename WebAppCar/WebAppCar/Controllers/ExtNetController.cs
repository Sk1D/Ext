using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using WebAppCar.Models;
using WebAppCar.BL;
using System.Collections.Generic;
using WebAppCar.BL.DTO;
using WebAppCar.ViewModel;
using AutoMapper;
using System;
using System.Collections;
using System.Linq;

namespace WebAppCar.Controllers
{
    public class ExtNetController : Controller
    {
        private IService serv;
        public ExtNetController(IService service)
        {
            this.serv = service;
        }
        //public ActionResult Index()
        //{
        //    ExtNetModel model = new ExtNetModel()
        //    {
        //        Title = "Welcome to Ext.NET",
        //        TextAreaEmptyText = ">> Enter a Message Here <<"
        //    };

        //    return this.View(model);
        //}

        //public ActionResult SampleAction(string message)
        //{
        //    X.Msg.Notify(new NotificationConfig
        //    {
        //        Icon = Icon.Accept,
        //        Title = "Working",
        //        Html = message
        //    }).Show();

        //    return this.Direct();
        //}

        public ActionResult CreateCountry(int? id)
        {
            if (id == null)
                return View();
            else
            {
                CountryDTO country = serv.GetCountryById(id.Value);
                Mapper.Initialize(cfg => cfg.CreateMap<CountryDTO, CountryViewModel>());
                var val =
                    Mapper.Map<CountryDTO, CountryViewModel>(country);
                return View(val);
            }

        }

        public ActionResult SuccessSubmitCountry(CountryViewModel country)
        {
            //X.Msg.Alert("Submit", JSON.Serialize(country)).Show();
            //return this.FormPanel(true);
            if(country.NameOfContry==null || country.Continent==null)
            {
                return this.FormPanel(true);
            }
            else
            {
                try
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<CountryViewModel, CountryDTO>());
                    var val =
                        Mapper.Map<CountryViewModel, CountryDTO>(country);
                    serv.AddCountry(val);
                    return RedirectToAction("Page2","Home");
                }

                catch (Exception e)
                {
                    throw new Exception("Error data automapper", e);
                }
            }
        }
        public ActionResult DeleteCountry(int? id)
        {
            serv.DelCountry(id.Value);
            return RedirectToAction("Country", "Home");

        }




  
        public DirectResult CellEditing(string id, string field, string oldValue, string newValue, object vmStock)
        {
            string json = JSON.Serialize(vmStock);
            json = json.Substring(2, json.Length - 4).Replace(@"\", "");
          CountryCarDTO vmStockObj = JSON.Deserialize<CountryCarDTO>(json);
            var listOfFieldNamesCar = typeof(CarDTO).GetProperties().Select(f => f.Name== field);
            var listOfFieldNamesCountry = typeof(CountryDTO).GetProperties().Select(f => f.Name == field);
            foreach(var item in listOfFieldNamesCar)
            {
                if(item==true)
                {
                    CarDTO car = new CarDTO { Id = vmStockObj.CarId, Brand = vmStockObj.Brand, Model = vmStockObj.Model };
                    serv.AddCar(car);
                }
            }
            foreach (var item in listOfFieldNamesCountry)
            {
                if (item == true)
                {
                    CountryDTO country = new CountryDTO { Id = vmStockObj.CountryId, Continent = vmStockObj.Continent, NameOfContry = vmStockObj.NameOfContry };
                    serv.AddCountry(country);
                }
            }


            Store store = X.GetCmp<Store>("Store");
            ModelProxy modelProxy = store.GetById(id);
            store.GetById(id).Commit();

            return this.Direct();
        }
 
        public ActionResult GetDataAction()
        {
           var values = serv.GetAllRelations();

            return this.Store(values);
        }
       
        public ActionResult Page3()
        {
            return View();
        }
        public ActionResult Reload()
        {
            return Redirect("Page3");
        }



    }
}