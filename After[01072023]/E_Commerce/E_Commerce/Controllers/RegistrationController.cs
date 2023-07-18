using E_Commerce.Models.Model;
using E_Commerce.Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class RegistrationController : Controller
    {
        IRegister register;
        public RegistrationController(IRegister register)
        {
            this.register = register;
        }
        // GET: Registration
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(register.GetALLCountry(), "CountryId", "CountryName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegistrationModel registrationModel)
        {

            //public string Profile_Picture { get; set; }
            //public HttpPostedFileBase ImageFile { get; set; }

            ViewBag.CountryList = new SelectList(register.GetALLCountry(), "CountryId", "CountryName");

            string ImagefileName = Path.GetFileNameWithoutExtension(registrationModel.ImageFile.FileName);
            string extension = Path.GetExtension(registrationModel.ImageFile.FileName);
            ImagefileName = ImagefileName + DateTime.Now.ToString("yymmddss") + extension;
            registrationModel.Profile_Picture = "~/ImageFolder/" + ImagefileName;
            ImagefileName = Path.Combine(Server.MapPath("~/ImageFolder/"), ImagefileName);

            var data = register.AddUser(registrationModel);

            if (data)
            {
                registrationModel.ImageFile.SaveAs(ImagefileName);
                //ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Something Wrong While Added";
                return View();
            }
            
        }

        public ActionResult GetStateList(int CountryId)
        {
            ViewBag.StateList = new SelectList(register.GetAllState(CountryId), "stateId", "stateName");
            return PartialView("DisplayState");

        }

        public ActionResult GetCityList(int StateId)
        {
            ViewBag.CityList = new SelectList(register.GetAllCity(StateId), "cityId", "cityName");
            return PartialView("DisplayCity");

        }
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(RegistrationModel registration)
        {
            string Login = register.LoginUser(registration);
            if (Login == "Invalid Email and Password" || Login == "Invalid Password" || Login == "Invalid Email")
            {
                TempData["Error"] = Login;
                return View();
            }
            else
            {
                Session["Email"] = Login;
                return RedirectToAction("Index", "Registration");
            }

        }
        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return View("Error");
            }
        }
    }
}