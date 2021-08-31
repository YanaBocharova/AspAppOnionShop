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
        public IActionResult Create(CreateProduct product)
        {
            if (!ModelState.IsValid || product.Category == null)
            {
                ModelState.AddModelError("", "Model is not valid!");
                return View(product);
            }
          
            productsService.CreateNewProduct(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid? id)
        {
            if (id is null || productsService.GetProductById((Guid)id) is null)
            {
                return BadRequest("Product was not found");
            }
            productsService.RemoveProductById((Guid)id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid? id)
        {
            if (id is null || productsService.GetProductById((Guid)id) is null)
            {
                return BadRequest("Product was not found");
            }
            return View(productsService.GetProductById((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel prod)
        {
            if (productsService.GetProductById((Guid)prod.Id) is null)
            {
                return BadRequest("Product was not found");
            }

            productsService.UpdateProduct(prod);
            return View(productsService.GetProductById(prod.Id));
        }

    }
}
