using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Models
{
    public class ProductRepositary : IProductRepositary
    {
        List<Product> productList;
        public ProductRepositary()
        {
            productList = new List<Product>();
        }
        public bool AddProduct(Product prod)
        {
            try
            {
                productList.Add(prod);
                return true;
            }
            catch { return false; }
        }

        public bool DeleteProduct(int prodId)
        {
            try
            {
                productList.Remove(productList.FirstOrDefault(p => p.Id == prodId));
                return true;
            }
            catch { return false; }
        }

        public List<Product> GetAllProduct()
        {
            return productList;
        }

        public Product getProductById(int prodId)
        {
            return productList.Where(p=>p.Id==prodId).FirstOrDefault();
        }
        public bool UpdateProduct(Product prod)
        {
            try
            {
                var UpdatedProd = productList.Find(p => p.Id == prod.Id);
                UpdatedProd.Name = prod.Name;
                UpdatedProd.color = prod.color;
                UpdatedProd.size = prod.size;
                UpdatedProd.price = prod.price;
                return true;

            }
            catch
            {
                return false;
            }

        }
    }
}
