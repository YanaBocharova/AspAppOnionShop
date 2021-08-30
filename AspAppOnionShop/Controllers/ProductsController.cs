using AspAppOnionShop.Models.Products;
using AspAppOnionShop.Sevices.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly IWebProductsService productsService;

        public ProductsController(IWebProductsService prodService)
        {
            this.productsService = prodService;
        }

        // [HttpGet]
        public IActionResult Index()
        {
            return View(new ProductsIndexViewModel
            {
                Products = productsService.GetAllProducts()
            });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model is not valid!");
                return View(product);
            }
            productsService.CreateNewProduct(product);
            return RedirectToAction("Index");
        }
    }
}
