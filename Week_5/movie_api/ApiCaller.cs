using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 
namespace api
{
    public class WebRequest
    {
        // The second parameter is a function that returns a Dictionary of string keys to object values.
        // If an API returned an array as its top level collection the parameter type would be "Action>"
        public static async Task GetFilmDataAsync(string term, Action<List<Film>>  Callback)
        {
            // Create a temporary HttpClient connection.
            using (var Client = new HttpClient())
            {
                try
                {
                    
                    Client.BaseAddress = new Uri($"https://api.themoviedb.org/3/search/movie?api_key=9053d7a271b82cb65b299800e362be0f&language=en-US&query={term}&page=1");
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // Read in the response as a string.
                    
                    JObject obj = JsonConvert.DeserializeObject<JObject>(StringResponse);
                    JArray filmList = obj["results"].Value<JArray>();
                    List<Film> films = new List<Film>();

                    foreach(JObject film in filmList)
                    {
                        films.Add(Film.FilmFromJson(film));
                    }
            
                    // Finally, execute our callback, passing it the response we got.
                    Callback(films);
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}