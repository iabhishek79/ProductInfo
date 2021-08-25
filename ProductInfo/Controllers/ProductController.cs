using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInfo.Controllers
{
    public class ProductController : Controller
    {
        IProductRepositary _productRepo;
        public ProductController(IProductRepositary productRepo)
        {
            _productRepo = productRepo;
        }
        // GET: Product
        public ActionResult Index()
        {
            var productList = _productRepo.GetAllProduct();
            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {

            var product = _productRepo.getProductById(id);
            if (product != null)
            {

                return View(product);
            }
            else
            {

                return View();
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Product product = new Product();

            var productList = _productRepo.GetAllProduct();
            if (productList?.Count == 0)
            {
                product.Id = 1;
            }
            else
            {
                product.Id = productList.Max(p => p.Id) + 1;
            }
            product.Name = collection["Name"];
            product.color = collection["Color"];
            product.size = collection["Size"];
            product.price = Convert.ToDouble(collection["Price"]);

            try
            {
                if (_productRepo.AddProduct(product))
                {
                    return RedirectToAction("index", "product");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productRepo.getProductById(id);
            if (product != null)
            {

                return View(product);
            }
            else
            {

                return View();
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var product = _productRepo.getProductById(id);

            product.Name = collection["Name"];
            product.color = collection["Color"];
            product.size = collection["Size"];
            product.price = Convert.ToDouble(collection["Price"]);
            try
            {
                if (_productRepo.UpdateProduct(product))
                {
                    return RedirectToAction("index", "product");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productRepo.getProductById(id);
            if (product != null)
            {

                return View(product);
            }
            else
            {

                return View();
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (_productRepo.DeleteProduct(id))
                {
                    return RedirectToAction("index", "product");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
