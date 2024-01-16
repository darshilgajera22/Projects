using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Products = await _context.Products.ToListAsync();

            if (Products == null || !Products.Any())
            {
                return NotFound();
            }

            return Products;
            
        }

        // GET: api/Products/5
        /*[HttpGet("{id}")]*/
        [HttpGet("ByCategory/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(int id)
        {
            var products = await _context.Products
                .Where(p => p.CategoryId == id && !p.Discontinued)
                .ToListAsync();
            
            if (products == null || !products.Any())
            {
                return NotFound();
            }

            return products;
        }
    }
}
