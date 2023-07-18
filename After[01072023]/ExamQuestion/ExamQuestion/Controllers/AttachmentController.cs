using ExamQuestion.Models.DbContext;
using ExamQuestion.Models.Model;
using ExamQuestion.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamQuestion.Controllers
{
    public class AttachmentController : Controller
    {
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();

        IAttech Attech;
        public AttachmentController(IAttech Attech)
        {
            this.Attech = Attech;
        }

        // GET: Attachment
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MiltipleAttachmentModel miltipleAttachmentModel)
        {

            string ImagefileName2 = Path.GetFileNameWithoutExtension(miltipleAttachmentModel.AttachmentFile.FileName);
            string extension2 = Path.GetExtension(miltipleAttachmentModel.AttachmentFile.FileName);
            ImagefileName2 = ImagefileName2 + DateTime.Now.ToString("yymmddss") + extension2;
            miltipleAttachmentModel.Attachment = "~/File/" + ImagefileName2;
            ImagefileName2 = Path.Combine(Server.MapPath("~/File/"), ImagefileName2);
            var data = Attech.AddUserInDB(miltipleAttachmentModel);
            if (data)
            {

                miltipleAttachmentModel.AttachmentFile.SaveAs(ImagefileName2);
                TempData["success"] = "Data Saved Successfully";
                ModelState.Clear();

                return RedirectToAction("Login", "User");
            }
            else
            {
                TempData["error"] = "Something Wrong While Added";
                return View();
            }



        }
        
        
        //[HttpPost]
        //public ActionResult Index(MiltipleAttachmentModel miltipleAttachmentModel, HttpPostedFileBase[] AttachmentFile)
        //{
        //    var data = Attech.AddUserInDB(miltipleAttachmentModel);
        //    if (data)
        //    {
        //        foreach (HttpPostedFileBase file in AttachmentFile)
        //        {
        //            if (file != null)
        //            {
        //                var InputFileName = Path.GetFileName(file.FileName);
        //                var ServerSavePath = Path.Combine(Server.MapPath("~/File/") + InputFileName);
        //                miltipleAttachmentModel.AttachmentFile.SaveAs(ServerSavePath);
        //            }
        //        }

        //    }
        //    else
        //    {
        //        TempData["error"] = "Something Wrong While Added";
        //        return View();
        //    }
        //    return View();
        //}



            
    }
}