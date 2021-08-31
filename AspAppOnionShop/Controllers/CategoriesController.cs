using AspAppOnionShop.Models.Categories;
using AspAppOnionShop.Sevices.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Controllers
{
    public class CategoriesController : Controller
    {
        private IWebCategoriesService categoriesService;

        public CategoriesController(IWebCategoriesService _categoriesService)
        {
            categoriesService = _categoriesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel category)
        {
            
            categoriesService.CreateNewCategory(category);
            return Ok();
        }
    }
}
