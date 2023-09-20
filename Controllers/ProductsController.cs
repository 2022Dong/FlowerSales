using FlowerSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //// Testing
        //[HttpGet]
        //public string GetProducts()
        //{
        //    return "OK";
        //}

        private readonly ShopContext _shopContext;

        public ProductsController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }
        //[HttpGet]
        //public IEnumerable<Product> GetAllProducts() // 1.b: Return a list of items
        //{
        //    return _shopContext.Products.ToList();
        //    //return _shopContext.Products.ToArray();
        //}

        //[HttpGet, Route("api/[controller]")]
        //public ActionResult GetProduct()  // 1.c: Returning multiple items
        //{
        //    return Ok(_shopContext.Products.ToList());
        //}

        //[HttpGet, Route("/products/{id}")]
        //public ActionResult GetProduct(int id)  // Returning a specific item
        //{
        //    // 1d. Error handling
        //    return Ok((_shopContext.Products.Find(id) != null)? _shopContext.Products.Find(id): NotFound("The id doesn't exist!"));
        //}

        [HttpGet, Route("api/[controller]")]
        public async Task<ActionResult> GetProduct()  // 1.e. Making all calls to your API Async
        {
            return Ok(await _shopContext.Products.ToListAsync());
        }

        [HttpGet, Route("/products/{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            // 1d. Error handling
            return Ok((await _shopContext.Products.FindAsync(id) != null) ?
                _shopContext.Products.Find(id) : NotFound("The id doesn't exist!"));
        }

        [HttpPost] // 1.f. Write data using HTTP methods.
        public async Task<ActionResult> PostProduct (Product product)
        {
            _shopContext.Products.Add(product);
            await _shopContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new {id = product.ProductId }, product);
        }

        [HttpPut("{id}")] // 1.h. Update one record using the PUT method.
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            if(id != product.ProductId) { return BadRequest("id != product.ProductId"); }

            _shopContext.Entry(product).State = EntityState.Modified; // updating data

            try { await _shopContext.SaveChangesAsync(); }
            catch(DbUpdateConcurrencyException ex) // data already have been modidied
            { 
                if(!_shopContext.Products.Any(p => p.ProductId == id)) { return NotFound(); }
                else { throw ex; }
            }
            return NoContent();
        }


    }
}
