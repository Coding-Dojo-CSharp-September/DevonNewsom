using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using mysql_test.Models;

namespace mysql_test.Controllers
{
    public class ArtistController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> artists = DbConnector.Query("SELECT * FROM artists");
            List<Dictionary<string, object>> albums = DbConnector.Query(
                @"SELECT artists.name AS artist_name, release_date, albums.name AS album_name, 
                artists.id AS artist_id, albums.id AS album_id FROM artists
                JOIN albums ON albums.artist_id = artists.id");
            ViewBag.Artists = artists;
            ViewBag.Albums = albums;
            return View(new IndexBundle{
                AlbumForm = new Album{ Artists = artists },
                ArtistForm = new Artist()
            });
        }
        [HttpPost]
        [Route("artist/create")]
        public IActionResult CreateArtist(string name)
        {
            string query = $"INSERT INTO artists (name) VALUES ('{name}')";
            var result = DbConnector.Query(query);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("album/create")]
        public IActionResult CreateAlbum(Album newAlbum)
        {
            string query = $@"INSERT INTO albums (name, release_date, artist_id) 
                            VALUES ('{newAlbum.Name}', '{newAlbum.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{newAlbum.ArtistId}')";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Show(int id)
        {
            string query = $"SELECT * FROM artists WHERE id = {id}";
            List<Dictionary<string, object>> artist = DbConnector.Query(query);
            ViewBag.Artist = artist[0];
            return View("Show");
        }
    }
}
