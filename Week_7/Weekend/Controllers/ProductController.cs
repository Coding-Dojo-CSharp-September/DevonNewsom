using Microsoft.AspNetCore.Mvc;
using Weekend.Models;
namespace Weekend.Controllers
{
    public class ProductController : Controller
    {
        // localhost:5000/product
        // localhost:5000/product/index
        public IActionResult Index()
        {
            return View();
        }
        // localhost:5000/product/show/3
        public IActionResult Show(int id)
        {
            ViewBag.ProductId = id;
            return View();        // localhost:5000/product/show

        }
        // localhost:5000/product/create        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            
            System.Console.WriteLine($"creating product {product.Name}");
            return RedirectToAction("Index");
        }
    }
}