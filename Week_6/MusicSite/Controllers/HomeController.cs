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
        [HttpPost]
        [Route("create")]
        public IActionResult Create(Artist artist)
        {
            if(ModelState.IsValid)
            {
                artistFactory.Add(artist);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("artist/{id}")]
        public IActionResult Show(int id)
        {
            return View(artistFactory.GetArtistById(id));
        }
      
    }
}
