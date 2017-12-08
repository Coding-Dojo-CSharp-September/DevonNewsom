using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HelloEF.Models;
using System.Linq;

namespace HelloEF.Controllers
{
    public class HomeController : Controller
    {
        private MusicContext _context;
        public HomeController(MusicContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Artists = _context.artists.ToList();

            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Artist artist)
        {
            // Check uniqueness of artist name
            if(_context.artists.Where(a => a.name == artist.name)
                               .ToList()
                               .Count() > 0)
            {
                ModelState.AddModelError("name", "Artist name already exists");
            }
            if(ModelState.IsValid)
            {
                _context.artists.Add(artist);
                _context.SaveChanges();
                return Json(artist);
            }
            return View("Index");
        }
        [HttpGet("artist/{id}")]
        public IActionResult Show(int id)
        {
            Artist thisArtist = _context.artists.SingleOrDefault(a => a.id == id);
            return View(thisArtist);
        }

        [HttpPost("artist/{id}")]
        public IActionResult Show(Artist artist)
        {
            if(ModelState.IsValid)
            {
                Artist toUpdate = _context.artists.SingleOrDefault(a => a.id == artist.id);
                toUpdate.name = artist.name;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Show", new {id=artist.id});
        }
    }
}
