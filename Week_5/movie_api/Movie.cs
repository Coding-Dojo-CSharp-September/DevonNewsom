using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace api
{
    public class Film
    {
        public string Title { get; set; }

        public float Rating { get; set; }        
        public DateTime ReleaseYear { get; set; }        
        public static Film FilmFromJson(JObject data)
        {
            Film film = new Film{
                Title = data["title"].Value<string>(),
                Rating = data["vote_average"].Value<float>(),
                ReleaseYear = data["release_date"].Value<DateTime>()
            };

            return film;
        }
    }
}