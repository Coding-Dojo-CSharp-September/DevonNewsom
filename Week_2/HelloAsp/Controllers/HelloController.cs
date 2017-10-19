using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace HelloAsp.Controllers
{
    public class HelloController : Controller
    {
        // :5000/
        // :5000/hello/
        // :5000/hello/index
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Fruit = new List<string> {"apple", "catelope", "cherrites"};
            if(HttpContext.Session.GetInt32("id") != null)
                ViewBag.UserId = HttpContext.Session.GetInt32("id");
            if(HttpContext.Session.GetString("name") != null)
                ViewBag.UserName = HttpContext.Session.GetString("name");
            return View();
        }

        [Route("sup")]
        public IActionResult Sup()
        {
            System.Console.WriteLine("HI IM IN SUP");
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [Route("submit")]
        public string Submit(string name, string location, DateTime dob)
        {

            HttpContext.Session.SetString("name", name);
            return $"{name}, {location}, {dob.ToString("D")}";
        }

        // :5000/hello/show/id?
        [Route("show/{id}")]
        public string Show(int id)
        {
            HttpContext.Session.SetInt32("id", id);
            return id.ToString();
        }
    }
}