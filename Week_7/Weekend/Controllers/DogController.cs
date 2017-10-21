using Microsoft.AspNetCore.Mvc;
using Weekend.Models;
namespace Weekend.Controllers
{
    public class DogController : Controller
    {
        // localhost:5000
        // localhost:5000/home
        // localhost:5000/home/index/2
        public IActionResult Index()
        {
            return View();
        }
        // localhost:5000/home/show/3
        // localhost:5000/home/show
        public IActionResult Show(int id)
        {
            ViewBag.UserId = id;
            return View();
        }
        // localhost:5000/home/create        
        [HttpPost]
        public IActionResult Create(Dog dog)
        {
            System.Console.WriteLine($"creating dog {dog.Name}");
            return RedirectToAction("Index");
        }
    }
}