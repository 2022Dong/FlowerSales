using FlowerSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSalesApi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ShopContext _shopContext;

        public CategoriesController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }

        [HttpGet, Route("/ReadAllCategories")]
        public ActionResult GetCategories()  // 1.c: Returning multiple items
        {
            return Ok(_shopContext.Categories.ToList());
        }
    }
}
