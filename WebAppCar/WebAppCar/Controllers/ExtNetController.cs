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

namespace WebAppCar.Controllers
{
    public class ExtNetController : Controller
    {
        private IService serv;
        public ExtNetController()
        {
            this.serv = new Service();
        }
        public ActionResult Index()
        {
            ExtNetModel model = new ExtNetModel()
            {
                Title = "Welcome to Ext.NET",
                TextAreaEmptyText = ">> Enter a Message Here <<"
            };

            return this.View(model);
        }

        public ActionResult SampleAction(string message)
        {
            X.Msg.Notify(new NotificationConfig
            {
                Icon = Icon.Accept,
                Title = "Working",
                Html = message
            }).Show();

            return this.Direct();
        }
        //public ActionResult CreateCountry()
        //{
        //    return View(GetData());
        //}
        //private object[] GetData()
        //{
        //    return new object[]
        //    {
        //    new object[] { "3m Co", 71.72, 0.02, 0.03, "9/1 12:00am" },
        //    new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "9/1 12:00am" },
        //    new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "9/1 12:00am" }
        //    };
        //}
        //public ActionResult Submit(string company, string lastChange, string pctChange, double price, int rating)
        //{
        //    X.Msg.Alert("Company", company).Show();
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

        //public ActionResult FailureSubmit(FormCollection values)
        //{
        //    var errors = new FieldErrors();

        //    foreach (var key in values.Keys)
        //    {
        //        errors.Add(new FieldError(key.ToString(), "Test error for " + key.ToString()));
        //    }

        //    return this.FormPanel("Error is emulated", errors);
        //}

        //public ActionResult DirectEventSubmit(Person person)
        //{
        //    X.Msg.Alert("Submit", JSON.Serialize(person)).Show();
        //    return this.Direct();
        //}
    }
}