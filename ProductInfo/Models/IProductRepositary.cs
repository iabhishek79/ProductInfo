using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Models
{
    public interface IProductRepositary
    {
        public bool AddProduct(Product prod);
        public bool UpdateProduct(Product prod);
        public List<Product> GetAllProduct();
        public Product getProductById(int id);
        public bool DeleteProduct(int prodId);

    }
}
