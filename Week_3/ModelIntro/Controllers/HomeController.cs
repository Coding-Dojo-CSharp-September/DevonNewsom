using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ModelIntro.Models;

namespace ModelIntro.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {

            //TempData["errors"] = new List<string> ();
            
            return View();
        }
        [Route("submit")]
        [HttpPost]
        public IActionResult Submission(User user)
        {
            List<string> errors = new List<string>();
            // all fields are required
            if(user.name == null || user.location == null || user.age == null)
            {
                errors.Add("All fields are required");
            }

            // user must be older than 65
            if(user.age < 65)
                errors.Add("user must be 65 or OLDER");
            TempData["errors"] = errors;

            return RedirectToAction("Index");
        }
    }
}