using CoffeeShop.Data.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Areas.Home.Controllers
{
    [Area("Home")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly CoffeeShopDbContext _context;

        public HomeController(CoffeeShopDbContext context)
        {
            _context = context;
        }

        [ActionName("Index")]
        public IActionResult Index()
        {
            var topProduct = _context.Products.Take(9);

            ViewData["IntroductTitle"] = "CAFÉ JW : Coffee xịn";

            return View(topProduct);
        }

        [ActionName("Cart")]
        public IActionResult Cart()
        {
            return View();
        }

        [ActionName("Library")]
        public IActionResult Library()
        {
            return View();
        }

        [ActionName("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [ActionName("News")]
        public IActionResult News()
        {
            return View();
        }

        [ActionName("Stores")]
        public IActionResult Stores()
        {
            return View();
        }
    }
}
