using GeneralStoreAPI.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeneralStoreAPI.Models;

namespace GeneralStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private GeneralStoreDbContext _db;
        public CustomerController(GeneralStoreDbContext db) {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerEdit newCustomer) {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            Customer customer = new Customer() {
                Name = newCustomer.Name,
                Email = newCustomer.Email,
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers() {
            var customers = await _db.Customers.ToListAsync();
            return Ok();
        }
    }
}