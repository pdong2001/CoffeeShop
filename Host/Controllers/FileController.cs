using CoffeeShop.Data.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly CoffeeShopDbContext _context;

        public FileController(CoffeeShopDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpLoad()
        {
            try
            {
                var file = Request.Form.Files[0];

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
                }
                if (toInsert.Id != 0)
                {
                    return Ok(new { id = toInsert.Id, success = true });
                }
                else
                {
                    return Ok(new { success = false, message = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new {success = false, message= ex.Message});
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var file = await _context.Images.FirstOrDefaultAsync(f => f.Id == id);
            if (file != null)
            {
                return new FileContentResult(file.Content, "image/jpeg");
            }
            else
            {
                throw new Exception("Image not found");
            }
        }
    }
}
