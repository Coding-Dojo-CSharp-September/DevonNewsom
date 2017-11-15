using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FormStuff.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            

            int? numTimes = HttpContext.Session.GetInt32("times");

            if(numTimes == null)
            {
                HttpContext.Session.SetInt32("times", 0);
            }
           
            ViewBag.Times = HttpContext.Session.GetInt32("times");
            return View();
        }

        [Route("formstuff")]
        [HttpPost]
        public IActionResult FormStuff(string favorite_color, string favorite_pizza)
        {
            // set session values (as a string)
            HttpContext.Session.SetString("pizza", favorite_pizza);
            HttpContext.Session.SetString("color", favorite_color);
            

            int? numTimes = HttpContext.Session.GetInt32("times");            

            numTimes++;
            HttpContext.Session.SetInt32("times", (int)numTimes);
         


            return RedirectToAction("ShowResults");
        }

        [Route("results")]
        public IActionResult ShowResults()
        {
            ViewBag.Pizza = HttpContext.Session.GetString("pizza");
            ViewBag.Color = HttpContext.Session.GetString("color");
            return View();
        }



    }
}
