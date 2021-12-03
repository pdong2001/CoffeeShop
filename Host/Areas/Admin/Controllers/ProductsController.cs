using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Data.Models;
using Data;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Host.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly CoffeeShopDbContext _context;

        public ProductsController(CoffeeShopDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            ViewData["username"] = HttpContext.User.Identity.Name;
            var coffeeShopDbContext = _context.Products.Include(p => p.Category);
            return View(await coffeeShopDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["username"] = HttpContext.User.Identity.Name;
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["username"] = HttpContext.User.Identity.Name;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,SmallImageFile,BannerImageFile,CategoryId,Price,Quantity,Weight")] Product product)
        {
            ViewData["username"] = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                if (product.SmallImageFile != null)
                {
                    var file = product.SmallImageFile;

                    var fileName = file.FileName;

                    Image toInsert;

                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        toInsert = new Image
                        {
                            Name = fileName,
                            Content = memoryStream.ToArray()
                        };
                        await _context.Images.AddAsync(toInsert);
                        product.SmallImageId = toInsert.Id;
                        product.SmallImage = toInsert;
                    }
                }
                if (product.BannerImageFile != null)
                {
                    var file = product.BannerImageFile;

                    var fileName = file.FileName;

                    Image toInsert;

                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        toInsert = new Image
                        {
                            Name = fileName,
                            Content = memoryStream.ToArray()
                        };
                        await _context.Images.AddAsync(toInsert);
                        product.BannerImageId = toInsert.Id;
                        product.BannerImage = toInsert;
                    }
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BannerImageId"] = new SelectList(_context.Images, "Id", "Id", product.BannerImageId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["SmallImageId"] = new SelectList(_context.Images, "Id", "Id", product.SmallImageId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["username"] = HttpContext.User.Identity.Name;

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BannerImageId"] = new SelectList(_context.Images, "Id", "Id", product.BannerImageId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["SmallImageId"] = new SelectList(_context.Images, "Id", "Id", product.SmallImageId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,SmallImageFile,BannerImageFile,CategoryId,Price,Quantity,Weight")] Product product)
        {
            ViewData["username"] = HttpContext.User.Identity.Name;
            var oldProduct = _context.Products.AsNoTracking().First(p => p.Id == id);
            product.SmallImageId = oldProduct.SmallImageId;
            product.BannerImageId = oldProduct.BannerImageId;
            if (product.SmallImageFile != null)
            {
                var file = product.SmallImageFile;

                var fileName = file.FileName;

                Image toInsert;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    toInsert = new Image
                    {
                        Name = fileName,
                        Content = memoryStream.ToArray()
                    };
                    await _context.Images.AddAsync(toInsert);
                    product.SmallImageId = toInsert.Id;
                    product.SmallImage = toInsert;
                }
            }
            if (product.BannerImageFile != null)
            {
                var file = product.BannerImageFile;

                var fileName = file.FileName;

                Image toInsert;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    toInsert = new Image
                    {
                        Name = fileName,
                        Content = memoryStream.ToArray()
                    };
                    await _context.Images.AddAsync(toInsert);
                    product.BannerImageId = toInsert.Id;
                    product.BannerImage = toInsert;
                }
            }

            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["username"] = HttpContext.User.Identity.Name;
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["username"] = HttpContext.User.Identity.Name;
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
