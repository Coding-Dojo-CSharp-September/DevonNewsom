using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace api.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("api/film/{term}")]
        public IActionResult Index(string term)
        {
            List<Film> films = new List<Film>();
            WebRequest.GetFilmDataAsync(term, response => {
                ViewBag.Films = response;
            }).Wait();

            return View();
        }
    }
}
