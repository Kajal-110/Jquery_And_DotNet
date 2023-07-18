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
    public class ImageController : Controller
    {
        ILogin LoginInterface;
        public ImageController(ILogin LoginInterface)
        {
            this.LoginInterface = LoginInterface;
        }
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ImageModel imageModel)
        {
                 //    public string ImagePath { get; set; }
                //public HttpPostedFileBase ImageFile { get; set; }


            string ImagefileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);          
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            ImagefileName = ImagefileName + DateTime.Now.ToString("yymmddss") + extension;
            imageModel.ImagePath = "~/ImageFolder/" + ImagefileName;           
            ImagefileName = Path.Combine(Server.MapPath("~/ImageFolder/"), ImagefileName);

            var data = LoginInterface.AddUser(imageModel);

            if (data)
            {
                imageModel.ImageFile.SaveAs(ImagefileName);
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Something Wrong While Added";
                return View();
            }


          
        }
       
        public ActionResult DisplayUser(int id)
        {
            var data = LoginInterface.ShowUser(id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return View();
            }
        }
        public ActionResult ImageList()
        {
            List<Image> images = new List<Image>();
            images = db.Image.ToList();
            return View(images);
        }

    }
}