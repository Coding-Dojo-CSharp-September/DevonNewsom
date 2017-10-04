using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace mysql_demo.Controllers
{
    public class ArtistController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string some_query_string = "SELECT * FROM artists";
            string some_other_query_string = "SELECT artists.name AS artist_name, albums.name AS album_name, release_date FROM albums JOIN artists ON albums.artist_id = artists.id";
            List<Dictionary<string,object>> artists = DbConnector.Query(some_query_string);
            List<Dictionary<string,object>> albums = DbConnector.Query(some_other_query_string);
            ViewBag.Artists = artists;
            ViewBag.Albums = albums;
            return View();
        }

        [HttpPost]
        [Route("artist/create")]
        public IActionResult CreateArtist(string name)
        {
            string some_query_string = $"INSERT INTO artists (name) VALUES ('{name}')";
            DbConnector.Execute(some_query_string);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("album/create")]
        public IActionResult CreateAlbum(string name, DateTime release_date, int artist_id)
        {
            string some_query_string = $"INSERT INTO albums (name, release_date, artist_id) VALUES ('{name}', '{release_date}', '{artist_id}')";
            DbConnector.Execute(some_query_string);
            return RedirectToAction("Index");
        }
    }
}
