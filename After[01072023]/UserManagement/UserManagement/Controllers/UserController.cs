using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Helpers.Helpers;
using UserManagement.Models.Context;
using UserManagement.Models.Models;
using UserManagement.Repositories.Repositories;

namespace UserManagement.Controllers
{
    public class UserController : Controller
    {
        Pooja326MVC3Entities entities = new Pooja326MVC3Entities();
        IUserInterface userInterface;

        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        // GET: User
      
  
    
      
        public ActionResult GetUserData(int? Id)
        {
            try
            {

                if (SessionHelper.Id != 0)
                {
                    Id = Convert.ToInt32(Session["id"]) + 0;
                }

                User user = entities.User.Where(m => m.Id == Id).FirstOrDefault();
                UserModel userModel = new UserModel();
                userModel.Id = user.Id;
                userModel.FirstName = user.FirstName;
                userModel.LastName = user.LastName;
                userModel.Email = user.Email;
                userModel.Password = user.Password;
                userModel.DOB = user.DOB;
                userModel.Address = user.Address;
                userModel.CountryId = user.CountryId;
                userModel.StateId = user.StateId != null ? user.StateId : 0;
                userModel.CityId = user.CityId != null ? user.StateId : 0;
                userModel.Attachment = user.Attachment;
                userModel.Gender = user.Gender;
                userModel.Hobbies = user.Hobbies;
                userModel.Profile = user.Profile;
                userModel.CountryName = user.Country.CountryName;
                userModel.Statename = user.States.StateName != null ? user.States.StateName : "";
                userModel.CityName = user.City.CityName != null ? user.City.CityName : "";


                if (userModel != null)
                {
                    return View(userModel);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserModel userModel)
        {
            try
            {
               
                int userLogin = userInterface.SignIn(userModel);
               
                 if (userLogin == 0)
                {
                    TempData["Error"] = "Invalid Password";
                    return View();
                }
                else if (userLogin == 00)
                {
                    TempData["Error"] = "User Not Registered";
                    return View();
                }
                else
                {
                    SessionHelper.Id = userLogin;
                    Session["Id"] = SessionHelper.Id;
                
                    return RedirectToAction("GetUserData");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

   
        public ActionResult SignUp()
        {
            try
            {
                ViewBag.CountryList = new SelectList(userInterface.SelectCountries(), "CountryId", "CountryName");

                return View();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

       
        [HttpPost]
        public ActionResult SignUp(UserModel userModel,HttpPostedFileBase[] files, HttpPostedFile IMAGEPath)
        {
            try
            {
                ViewBag.CountryList = new SelectList(userInterface.SelectCountries(), "CountryId", "CountryName");


                string FileName = Path.GetFileNameWithoutExtension(userModel.IMAGEPath.FileName);
                string FileExtension = Path.GetExtension(userModel.IMAGEPath.FileName);
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                userModel.Profile = UploadPath + FileName;
                userModel.IMAGEPath.SaveAs(userModel.Profile);

                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Uploads/") + InputFileName);
                        file.SaveAs(ServerSavePath);

                        ViewBag.UploadStatus = files.Count().ToString() + "files uploaded successfully";
                    }
                }

                SessionHelper.Email = userModel.Email;
                Session["Email"] = SessionHelper.Email;
                SessionHelper.Firstname = userModel.FirstName;
                Session["Firstname"] = SessionHelper.Firstname;
                SessionHelper.Lastname = userModel.LastName;
                Session["Lastname"] = SessionHelper.Lastname;
                Session["Fullname"] = SessionHelper.Firstname + " " + SessionHelper.Lastname;
                User user = new User();
                user.Id = userModel.Id;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Email = userModel.Email;
                user.Password = userModel.Password;
                user.DOB = userModel.DOB;
                user.Address = userModel.Address;
                user.CountryId = userModel.CountryId;
                user.StateId = userModel.StateId;
                user.CityId = userModel.CityId;
                user.Attachment = userModel.Attachment;
                user.Gender = userModel.Gender;
                user.Hobbies = userModel.Hobbies;
                user.Profile = userModel.Profile;
                var check = entities.User.Any(m => m.FirstName == userModel.FirstName && m.LastName == userModel.LastName);
                if (check)
                {
                    TempData["Error"] = "User Already Exists";
                    return View();
                }
                else
                {
                    entities.User.Add(user);
                    entities.SaveChanges();
                    return RedirectToAction("SignIn");
                }

            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        public JsonResult StateList(int Id)
        {
            try
            {
                var state = from s in entities.States
                            where s.CountryId == Id
                            select s;
                return Json(new SelectList(state.ToArray(), "StateId", "StateName"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public JsonResult Citylist(int id)
        {
            try
            {
                var city = from c in entities.City
                           where c.StateId == id
                           select c;
                return Json(new SelectList(city.ToArray(), "CityId", "CityName"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IList<States> Getstate(int CountryId)
        {
            try
            {
                return entities.States.Where(m => m.CountryId == CountryId).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadClassesByCountryId(string CountryName)
        {
            try
            {
                var stateList = this.Getstate(Convert.ToInt32(CountryName));
                var stateData = stateList.Select(m => new SelectListItem()
                {
                    Text = m.StateName,
                    Value = m.CountryId.ToString(),
                });
                return Json(stateData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}