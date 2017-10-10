using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MusicSite.Models;
namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        private ArtistFactory artistFactory;
        public HomeController()
        {
            artistFactory = new ArtistFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Artists = artistFactory.FindAll();
            return View();
        }
    }
}
