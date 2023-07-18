using ExamQuestion.Helper.Helpers;
using ExamQuestion.Models.DbContext;
using ExamQuestion.Models.Model;
using ExamQuestion.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamQuestion.Controllers
{
    public class UserController : Controller
    {
        IUser UserInterface;
        public UserController(IUser UserInterface)
        {
            this.UserInterface = UserInterface;
        }
        // GET: User
        public ActionResult RegisterUser()
        {
            ViewBag.CountryList = new SelectList(UserInterface.GetALLCountry(), "CountryId", "CountryName");
            return View();

        }
        [HttpPost]
        public ActionResult RegisterUser(RegistrationModel registration, string Danching,string Reading,string  Cooking)
        {
            KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();

            ViewBag.CountryList = new SelectList(UserInterface.GetALLCountry(), "CountryId", "CountryName");

            /*string FileName = Path.GetFileNameWithoutExtension(registration.IMAGEPath.FileName);
            string FileExtension = Path.GetExtension(registration.IMAGEPath.FileName);
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
            registration.Profile_photo = UploadPath + FileName;
            registration.IMAGEPath.SaveAs(registration.Profile_photo);*/
            string ImagefileName = Path.GetFileNameWithoutExtension(registration.IMAGEPath.FileName);
            /*string ImagefileName2 = Path.GetFileNameWithoutExtension(registration.FileData.FileName);*/
            string extension = Path.GetExtension(registration.IMAGEPath.FileName);
            /*string extension2 = Path.GetExtension(registration.FileData.FileName);*/
            ImagefileName = ImagefileName + DateTime.Now.ToString("yymmddss") + extension;
            /*ImagefileName2 = ImagefileName2 + DateTime.Now.ToString("yymmddss") + extension2;*/
            registration.Profile_photo = "~/ImageFolder/" + ImagefileName;
            /*registration.Attachment = "~/File/" + ImagefileName2;*/
            ImagefileName = Path.Combine(Server.MapPath("~/ImageFolder/"), ImagefileName);
            /*ImagefileName2 = Path.Combine(Server.MapPath("~/File/"), ImagefileName2);*/
            var data = UserInterface.AddUser(registration);
            /*
                        Registration registration1 = new Registration();
                        registration1 = UserHelper.ConvertToCustomModel(registration);*/

            /*            registration1.IsIntrestedInDanching = (Danching == "true") ? true : false;
                        registration1.IsIntrestedInReading= (Reading == "true") ? true : false;
                        registration1.IsIntrestedInCooking= (Cooking == "true") ? true : false;*/
            if (data)
            {
                registration.IMAGEPath.SaveAs(ImagefileName);
                ModelState.Clear();
                return RedirectToAction("Login", "User");
            }
            else
            {
                TempData["error"] = "Something Wrong While Added";
                return View();
            }
            /*var check = db.Registration.Any(x => x.FirstName == registration.FirstName && x.LastName == registration.LastName);

            if (check)
            {
                TempData["Error"] = "User Already Exists";
                return View();
            }
            else
            {
                db.Registration.Add(registration1);
                db.SaveChanges();
                return RedirectToAction("Login");
            }*/
           
        }

        public ActionResult GetStateList(int CountryId)
        {
            ViewBag.StateList = new SelectList(UserInterface.GetAllState(CountryId), "StateId", "StateName");
            return PartialView("DisplayState");

        }

        public ActionResult GetCityList(int StateId)
        {
            ViewBag.CityList = new SelectList(UserInterface.GetAllCity(StateId), "CityId", "CityName");
            return PartialView("DisplayCity");

        }

        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(RegistrationModel registration)
        {
            string Login = UserInterface.LoginUser(registration);
            if (Login == "Invalid Email and Password" || Login == "Invalid Password" || Login == "Invalid Email")
            {
                TempData["Error"] = Login;
                return View();
            }
            else
            {
                Session["Email"] = Login;
                return RedirectToAction("RegisterUser");
            }

        }

        /* public ActionResult Details()
         {
             List<RegistrationModel> registrationModels = new List<RegistrationModel>();
             registrationModels = UserInterface.GetAllUser();
             return View(registrationModels);
         }*/

        public ActionResult DisplayUser(int id)
        {
            var data = UserInterface.ShowUser(id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return View();
            }
        }

    }
}