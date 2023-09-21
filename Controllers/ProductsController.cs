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

        [HttpGet, Route("/ReadAllProducts")]
        public async Task<ActionResult> GetProduct([FromQuery] ProductQueryParameters queryParameters)
        {

            IQueryable<Product> products = _shopContext.Products;
            // filter
            if (queryParameters.MaxPrice != null)
            {
                products = products.Where(
                    p => p.Price <= queryParameters.MaxPrice.Value);
            }
            if (queryParameters.MinPrice != null)
            {
                products = products.Where(
                    p => p.Price >= queryParameters.MinPrice.Value);
            }
            // IsAvialable...
            //...
            // pagination 
            products = products.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);

            return Ok(await products.ToListAsync());
        }
        //[HttpGet, Route("/ReadAllProducts")]
        //public async Task<ActionResult> GetProduct()  // 1.e. Making all calls to your API Async
        //{
        //    return Ok(await _shopContext.Products.ToListAsync());
        //}
        [HttpGet, Route("/ReadOneProductById")]
        public async Task<ActionResult> GetProduct(int id)
        {
            // 1d. Error handling
            return Ok((await _shopContext.Products.FindAsync(id) != null) ?
                _shopContext.Products.Find(id) : NotFound("The id doesn't exist!"));
        }

        [HttpPost, Route("/AddProduct")] // 1.f. Write data using HTTP methods.
        public async Task<ActionResult> PostProduct(Product product)
        {
            _shopContext.Products.Add(product);
            await _shopContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        [HttpPut, Route("/UpdateOneId")] // 1.h. Update one record using the PUT method.
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId) { return BadRequest("id != product.ProductId"); }

            _shopContext.Entry(product).State = EntityState.Modified; // updating data

            try { await _shopContext.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException ex) // data already have been modidied
            {
                if (!_shopContext.Products.Any(p => p.ProductId == id)) { return NotFound(); }
                else { throw ex; }
            }
            return NoContent();
        }

        [HttpDelete, Route("/DeleteOneId")] // 1.i. Delete one or many records using DELETE.
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            Product product = await _shopContext.Products.FindAsync(id);
            if (product != null)
            {
                return NotFound();
            }

            _shopContext.Products.Remove(product);
            await _shopContext.SaveChangesAsync();

            return product;
        }

        [HttpDelete, Route("/DeleteMultipleIds")]
        public async Task<ActionResult<Product>> DeleteProducts([FromQuery] int[] ids)
        {
            List<Product> products = new List<Product>();
            foreach (int id in ids)
            {
                Product product = await _shopContext.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                products.Add(product);
            }
            _shopContext.Products.RemoveRange(products);
            await _shopContext.SaveChangesAsync();

            return Ok(products);
        }
    }
}
