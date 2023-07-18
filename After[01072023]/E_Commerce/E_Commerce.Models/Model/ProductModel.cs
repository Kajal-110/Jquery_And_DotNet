using E_Commerce.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce.Models.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Product_Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> categoryId { get; set; }

        public string categoryName { get; set; }
        public string Product_Image { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public virtual Category Category { get; set; }
    }
}
