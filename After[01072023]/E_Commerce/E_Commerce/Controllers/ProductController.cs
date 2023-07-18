using E_Commerce.Models.DbContext;
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
    public class ProductController : Controller
    {
        IProduct ProductInterface;
        public ProductController(IProduct ProductInterface)
        {
            this.ProductInterface = ProductInterface;
        }
        Kajal_PatelEntities db = new Kajal_PatelEntities();
        // GET: Product
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(CategoryList(), "categoryId", "categoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            ViewBag.CategoryList = new SelectList(CategoryList(), "categoryId", "categoryName");

            //public string Profile_Picture { get; set; }
            //public HttpPostedFileBase ImageFile { get; set; }

            string ImagefileName = Path.GetFileNameWithoutExtension(productModel.ImageFile.FileName);
            string extension = Path.GetExtension(productModel.ImageFile.FileName);
            ImagefileName = ImagefileName + DateTime.Now.ToString("yymmddss") + extension;
            productModel.Product_Image = "~/ImageFolder/" + ImagefileName;
            ImagefileName = Path.Combine(Server.MapPath("~/ImageFolder/"), ImagefileName);

            var data = ProductInterface.AddProduct(productModel);

            if (data)
            {
                productModel.ImageFile.SaveAs(ImagefileName);
                //ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Something Wrong While Added";
                return View();
            }
        }

        public List<Category> CategoryList()
        {
            List<Category> categories= db.Category.ToList();
            return (categories);
        }
        public ActionResult ProductList()
        {
            var aa = ProductInterface.GetAllProduct();
            return View(aa);
        }

        public ActionResult GetProductById(int id)
        {
            ProductModel productModel = ProductInterface.GetProductById(id);
            return View(productModel);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = new SelectList(CategoryList(), "categoryId", "categoryName");
            ProductModel productModel = ProductInterface.EditProductModel(id);
            return View(productModel);
        }
        [HttpPost]
        public ActionResult Edit(ProductModel productModel)
        {
            ViewBag.CategoryList = new SelectList(CategoryList(), "categoryId", "categoryName");
            var aa =ProductInterface.PostProductData(productModel);
            return RedirectToAction("ProductList");
        }
        public ActionResult Delete(int id)
        {
            ProductInterface.DeleteProduct(id);
            return RedirectToAction("ProductList");
        }
    }
}