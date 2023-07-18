using Krunal_Final_Test_Model.Context;
using Krunal_Final_Test_Model.Model;
using Krunal_Final_Test_Repository.Repository;
using Krunal_Final_Test_Repository.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Krunal_Final_Test.Controllers
{
    public class UserController : Controller
    {
        IUser UserServices;

        public UserController(UserServices _UserServices)
        {
            UserServices = _UserServices;
        }

        public static User_Registration_Model userdetail = new User_Registration_Model();
        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User_Registration_Model user_Registration_Model)
        {
            try
            {
                User_Registration user_info = UserServices.CheckEmail_Password(user_Registration_Model);
                if (user_info != null)
                {
                    TempData["success"] = "Login SuccessFul";
                    TempData["show"] = "yes";
                    Session["User"] = "Hello ! Welcome " + user_info.FirstName + user_info.LastName;
                    return RedirectToAction("DisplayUser", "User",new { id = user_info.id});
                }
                else
                {
                    TempData["error"] = "Wrong Password !";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            //Logout
            public ActionResult Logout()
            {
            try
            {
                if(Session["User"]!= null)
                {
                    HttpContext.Session.Clear();
                    TempData["success"] = "Logout SuccessFul";
                    TempData["show"] = null;
                    return RedirectToAction("Login","User");
                }
                else
                {
                    HttpContext.Session.Clear();
                    TempData["success"] = "Logout SuccessFul";
                    TempData["show"] = null;
                    return RedirectToAction("Login","User");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetStatesByCountryId(int countryId)
        {
            return Json(UserServices.GetStateByCountryId(countryId), JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCityFromId(int stateId)
        {
            return Json(UserServices.GetCityByStateId(stateId), JsonRequestBehavior.AllowGet);
        }

        // Add User
        public ActionResult AddUser()
        {
            try
            {
                ViewBag.CountryList = UserServices.getCountryList();
                ViewBag.StateList = UserServices.getStateList();
                ViewBag.CityList = UserServices.getCityList();
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult AddUser(User_Registration_Model user_Registration_Model)
        {
            try
            {
                string ImagefileName = Path.GetFileNameWithoutExtension(user_Registration_Model.ImageFile.FileName);
                string ImagefileName2 = Path.GetFileNameWithoutExtension(user_Registration_Model.FileData.FileName);
                string extension = Path.GetExtension(user_Registration_Model.ImageFile.FileName);
                string extension2 = Path.GetExtension(user_Registration_Model.FileData.FileName);
                ImagefileName = ImagefileName + DateTime.Now.ToString("yymmddss") + extension;
                ImagefileName2 = ImagefileName2 + DateTime.Now.ToString("yymmddss") + extension2;
                user_Registration_Model.PhotoPath = "~/Image/" + ImagefileName;
                user_Registration_Model.Docpath = "~/File/" + ImagefileName2;
                ImagefileName = Path.Combine(Server.MapPath("~/Image/"), ImagefileName);
                ImagefileName2 = Path.Combine(Server.MapPath("~/File/"), ImagefileName2);
                var data = UserServices.AddUserInDB(user_Registration_Model);
                if (data)
                {
                    user_Registration_Model.ImageFile.SaveAs(ImagefileName);
                    user_Registration_Model.FileData.SaveAs(ImagefileName2);
                    TempData["success"] = "Data Saved Successfully";
                    ModelState.Clear();
                    ViewBag.CountryList = UserServices.getCountryList();
                    ViewBag.StateList = UserServices.getStateList();
                    ViewBag.CityList = UserServices.getCityList();
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    TempData["error"] = "Something Wrong While Added";
                    ViewBag.CountryList = UserServices.getCountryList();
                    ViewBag.StateList = UserServices.getStateList();
                    ViewBag.CityList = UserServices.getCityList();
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult DisplayUser(int id)
        {
            var data = UserServices.ShowUser(id);
            if (data != null)
            {
                TempData["show"] = "yes";
                return View(data);
            }
            else
            {
                return View();
            }
        }

        //Update
        public ActionResult UpdateData(int id)
        {
            try
            {
                ViewBag.CountryList = UserServices.getCountryList();
                ViewBag.StateList = UserServices.getStateList();
                ViewBag.CityList = UserServices.getCityList();
                var data = UserServices.GetUserById(id);
                return View(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult UpdateData(int id,User_Registration_Model user_Registration_Model)
        {
            try
            {
                string ImagefileName = Path.GetFileNameWithoutExtension(user_Registration_Model.ImageFile.FileName);
                string ImagefileName2 = Path.GetFileNameWithoutExtension(user_Registration_Model.FileData.FileName);
                string extension = Path.GetExtension(user_Registration_Model.ImageFile.FileName);
                string extension2 = Path.GetExtension(user_Registration_Model.FileData.FileName);
                ImagefileName = ImagefileName + DateTime.Now.ToString("yymmddss") + extension;
                ImagefileName2 = ImagefileName2 + DateTime.Now.ToString("yymmddss") + extension2;
                user_Registration_Model.PhotoPath = "~/Image/" + ImagefileName;
                user_Registration_Model.Docpath = "~/File/" + ImagefileName2;
                ImagefileName = Path.Combine(Server.MapPath("~/Image/"), ImagefileName);
                ImagefileName2 = Path.Combine(Server.MapPath("~/File/"), ImagefileName2);
                var data = UserServices.UpdateUser(id, user_Registration_Model);
                if (data == true)
                {
                    user_Registration_Model.ImageFile.SaveAs(ImagefileName);
                    user_Registration_Model.FileData.SaveAs(ImagefileName2);
                    TempData["success"] = "Update Successfully";
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    TempData["error"] = "Not Updated";
                    return View(); ;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}