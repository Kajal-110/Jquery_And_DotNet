using E_Commerce.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        Kajal_PatelEntities db = new Kajal_PatelEntities();
        // GET: Category
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    db.Category.Add(category);
                    db.SaveChanges();
                    TempData["Message"] = "Product Added Successfully";
                    return View();
                }
                else
                {
                    return View();
                }


            }
            catch (Exception e)
            {
                TempData["Message"] = "Product Added failed...." + e.Message;
                return View();
            }
        }

        public ActionResult CategoryList()
        {
            List<Category> categories = new List<Category>();
            categories = db.Category.ToList();
            return View(categories);
        }

        public ActionResult Delete(int id)
        {
            var category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}