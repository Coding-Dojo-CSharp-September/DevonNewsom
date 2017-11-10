using Microsoft.AspNetCore.Mvc;
namespace AspFunzies.Controllers
{
    public class CoolController : Controller
    {
        //@app.route("")

        [HttpGet("")]
        public IActionResult Hello()
        {
            string[] animals = 
            {
                "Moose",
                "Chicken",
                "Frog",
                "Horse",
                "Pengin",
                "Big Bear"
            };
            ViewBag.Animals = animals;
            ViewBag.NotHere = "HERE NOW";

            return View("Hello");
        }
        [HttpPost("submit")]
        public IActionResult Send(string first, string last)
        {

            object postData = new 
            {
                FirstName=first,
                LastName=last
            };
            return Json(postData);
        }

        [HttpGet]
        [Route("lol")]
        public IActionResult RedirectStuff()
        {
            System.Console.WriteLine("I am redirecting!!!");
            return RedirectToAction("Hello");
        }
        [HttpGet]
        [Route("json")]
        public IActionResult JsonThis()
        {
            return Json("this is json!!!");
        }
    }
}