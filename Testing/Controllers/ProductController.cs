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
            return View();
        }
    }
}
