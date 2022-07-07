using GeneralStoreAPI.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeneralStoreAPI.Models;

namespace GeneralStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private GeneralStoreDbContext _db;
        public ProductController(GeneralStoreDbContext db) {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductEdit newProduct) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Product product = new Product() {
                Name = newProduct.Name,
                Price = newProduct.Price,
                QuantityInStock = newProduct.QuantityInStock,
            };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }
    }
}