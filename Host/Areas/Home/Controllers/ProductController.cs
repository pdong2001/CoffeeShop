using CoffeeShop.Data.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Host.Areas.Home.Controllers
{
    [Area("Home")]
    public class ProductController : Controller
    {
        private readonly CoffeeShopDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public ProductController(CoffeeShopDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [ActionName("Product")]
        public IActionResult Product()
        {
            Product[] products = _context.Products.Where(p => p.Quantity > 0).ToArray();
            return View(products);
        }

        [HttpGet]
        [ActionName("GetOne")]
        public Product GetOne(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        [ActionName("ProductDetail"), HttpGet]
        public IActionResult ProductDetail(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction(nameof(Product));
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        [ActionName("Cart")]
        [Authorize]
        public IActionResult Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Product[] prods = new Product[0];
            if (userId != null)
            {
                var products = from p in _context.Products
                               join cm in _context.CartMaps
                               on p.Id equals cm.ProductId
                               where cm.UserId == userId
                               select p;
                prods = products.ToArray();
            }

            return View(prods);
        }
    }
}
