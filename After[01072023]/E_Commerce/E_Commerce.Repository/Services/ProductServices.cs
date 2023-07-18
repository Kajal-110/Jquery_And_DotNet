using E_Commerce.Helpers.Helper;
using E_Commerce.Models.DbContext;
using E_Commerce.Models.Model;
using E_Commerce.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Services
{
    public class ProductServices: IProduct
    {

        Kajal_PatelEntities db = new Kajal_PatelEntities();
        public bool AddProduct(ProductModel productModel)
        {
            Product product = new Product();

            product = ProductHelper.ConvertToDB(productModel);

            if (product != null)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAllProduct()
        {

            List<Product> product = new List<Product>();

            product = db.Product.ToList();
            return product;
        }

        public ProductModel GetProductById(int Id)
        {
            try
            {
                var product = db.Product.Where(x => x.ProductId == Id).FirstOrDefault();
                if(product != null)
                {
                    ProductModel productModel = ProductHelper.ConvertToCustome(product);
                    return productModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public ProductModel EditProductModel(int Id)
        {
            try
            {
                Product product = db.Product.Find(Id);
                ProductModel productModel = ProductHelper.ConvertToCustome(product);
                return productModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int PostProductData(ProductModel productModel)
        {
            try
            {
                var product = ProductHelper.ConvertToDB(productModel);
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Product DeleteProduct(int id)
        {
            try
            {
                var delete = db.Product.Find(id);
                if(delete!= null)
                {
                    Product product = db.Product.Remove(delete);
                    db.SaveChanges();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
