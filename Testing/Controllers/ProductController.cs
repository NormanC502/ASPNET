using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public ProductController(IProductRepository repository) 
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var products = repository.GetAllProducts(); // coonection for view of the products query from the method GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id) 
        {
            var product = repository.GetProduct(id);
            return View(product);
        }

        public IActionResult UpdateProduct(int id) 
        {
            Product product = repository.GetProduct(id);
                if (product == null) 
                {
                     return View("ProductNotFound");
                }

                    return View(product);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            repository.UpdateProduct(product);
            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct()
        {
            var product = repository.AssignCategory();

            return View(product);
        }
        
        public IActionResult InsertProductToDatabase(Product productToInsert) 
        {
            repository.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Product product)
        {
            repository.DeleteProduct(product);

            return RedirectToAction("Index");
        }

    }
}
