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
            ViewBag.Artists = _context.artists.ToList();

            ViewBag.User = _context.users
                .Include(u => u.LikedArtists)
                .SingleOrDefault(u => u.user_id == HttpContext.Session.GetInt32("id"));

            //user.LikedArtists.Any(l => l.artist_id == 3);
            ArtistIndex model = new ArtistIndex()
            {
                User = _context.users
                    .Include(u => u.LikedArtists)
                    .SingleOrDefault(u => u.user_id == HttpContext.Session.GetInt32("id")),
                Artists = _context.artists.ToList()
            };

            return View(model);
        }
        [HttpGet("like/{artist_id}")]
        public IActionResult Like(int artist_id)
        {
            User user = _context.users
                    .Include(u => u.LikedArtists)
                    .SingleOrDefault(u => u.user_id == HttpContext.Session.GetInt32("id"));

            // check if artist has already been liked by user
            if(_context.likes.Where(l => l.artist_id == artist_id)
                .FirstOrDefault(l => l.user_id == user.user_id) == null)
            {
                Like like = new Like()
                {
                    created_at = DateTime.Now,
                    user_id = user.user_id,
                    artist_id = artist_id
                };
                _context.likes.Add(like);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}















// [HttpPost("artist/create")]
//         public IActionResult Create(ArtistIndex model)
//         {
//             Artist artist = model.Artist;
//             // Check uniqueness of artist name
//             if(_context.artists.Where(a => a.name == artist.name)
//                                .ToList()
//                                .Count() > 0)
//             {
//                 ModelState.AddModelError("name", "Artist name already exists");
//             }
//             if(ModelState.IsValid)
//             {
//                 _context.artists.Add(artist);
//                 _context.SaveChanges();
//                 return RedirectToAction("Index");
//             }
//             model.Artists = _context.artists.ToList();
//             model.User = ActiveUser;
//             return View("Index", model);
//         }

// [HttpGet("artist/{id}")]
//         public IActionResult Show(int id)
//         {
//             Artist thisArtist = _context.artists
//                 .SingleOrDefault(a => a.artist_id == id);


//             return View(thisArtist);
//         }

//         [HttpPost("artist/{id}")]
//         public IActionResult Show(Artist artist)
//         {
//             if(ModelState.IsValid)
//             {
//                 Artist toUpdate = _context.artists.SingleOrDefault(a => a.artist_id == artist.artist_id);
//                 toUpdate.name = artist.name;
//                 _context.SaveChanges();
//                 return RedirectToAction("Index");
//             }
//             return View("Show", new {id=artist.artist_id});
//         }