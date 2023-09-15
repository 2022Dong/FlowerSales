using FlowerSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _shopContext.Products.ToArray();
        }
    }
}
