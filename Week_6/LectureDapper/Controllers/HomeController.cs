using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LectureDapper.Models;

namespace LectureDapper.Controllers
{
    public class HomeController : Controller
    {
        private ArtistFactory artistFactory;
        public HomeController()
        {
            artistFactory = new ArtistFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Artists = artistFactory.GetAllArtists();
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Artist artist)
        {
            // ensure uniqueness of artist.name
            if(!artistFactory.ArtistNameIsUnique(artist.name))
                ModelState.AddModelError("name", "Artist name already exists!");

            if(ModelState.IsValid)
            {
                artistFactory.CreateArtist(artist);
                RedirectToAction("Index");
            }
            ViewBag.Artists = artistFactory.GetAllArtists();
            return View("Index");
        }

        [HttpGet("artist/{id}")]
        public IActionResult Show(int id)
        {
            Artist theArtist = artistFactory.GetArtistById(id);
            return View(theArtist);
        }
    }
}
