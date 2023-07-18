using E_Commerce.Models.DbContext;
using E_Commerce.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Helpers.Helper
{
    public static class ProductHelper
    {
        public static Product ConvertToDB (ProductModel productModel)
        {
            Product product = new Product();
            product.ProductId = productModel.ProductId;
            product.Product_Title = productModel.Product_Title;
            product.Price = productModel.Price;
            product.Description = productModel.Description;
            product.Product_Image = productModel.Product_Image;
            product.categoryId = productModel.categoryId;
            
           // product.Category.categoryName = productModel.Category.categoryName;
            return product;
        }

        public static ProductModel ConvertToCustome(Product product)
        {
            ProductModel productModel = new ProductModel();
            productModel.ProductId = product.ProductId;
            productModel.Product_Title = product.Product_Title;
            productModel.Price = product.Price;
            productModel.Description = product.Description;
            productModel.Product_Image = product.Product_Image;
            productModel.categoryId = product.categoryId;
            
            return productModel;
        }
    }
}
