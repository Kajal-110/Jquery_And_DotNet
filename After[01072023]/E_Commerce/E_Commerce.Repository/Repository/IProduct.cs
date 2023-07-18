using E_Commerce.Models.DbContext;
using E_Commerce.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public interface IProduct
    {
        bool AddProduct(ProductModel productModel);
        List<Product> GetAllProduct();
        ProductModel GetProductById(int Id);
        ProductModel EditProductModel(int Id);
        int PostProductData(ProductModel productModel);
        Product DeleteProduct(int id);
    }
}
