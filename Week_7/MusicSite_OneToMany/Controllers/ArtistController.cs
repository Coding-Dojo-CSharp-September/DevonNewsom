using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HelloEF.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HelloEF.Controllers
{
    public class ArtistController : Controller
    {
        private MusicContext _context;
        public ArtistController(MusicContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("artist")]
        public IActionResult Index()
        {
            User user = _context.users.SingleOrDefault(u => u.user_id == 10);

            ViewBag.Artists = _context.artists.ToList();

            return View();
        }

        [HttpPost("artist/create")]
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
            Artist thisArtist = _context.artists
                // Include the List<Album> reference to related Album objects
                .Include(a => a.albums)
                .SingleOrDefault(a => a.artist_id == id);

            ShowArtist modelForView = new ShowArtist()
            {
                Artist = thisArtist,
                NewAlbum = new Album()
            };

            return View(modelForView);
        }

        [HttpPost("artist/{id}")]
        public IActionResult Show(ShowArtist model)
        {
            Artist artist = model.Artist;
            if(ModelState.IsValid)
            {
                Artist toUpdate = _context.artists.SingleOrDefault(a => a.artist_id == artist.artist_id);
                toUpdate.name = artist.name;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Show", new {id=artist.artist_id});
        }
        [HttpPost("album/create")]
        public IActionResult CreateAlbum(ShowArtist model)
        {
            Album album = model.NewAlbum;
            if(ModelState.IsValid)
            {
                _context.albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction("Show", new {id=album.artist_id});
            }
            model.Artist = _context.artists.SingleOrDefault(a => a.artist_id == album.artist_id);
            return View("Show", model);
        }
    }
}
