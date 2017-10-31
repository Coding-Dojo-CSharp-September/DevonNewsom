using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace NewProj
{
    public class PokeObject
    {
        public string name;
        public string weight;
        public string height;
        public string image;
        public PokeObject(Dictionary<string, object> jsonData)
        {
            JObject sprites = jsonData["sprites"] as JObject;
            
            name = jsonData["name"].ToString();
            weight = jsonData["weight"].ToString();
            height = jsonData["height"].ToString();
            image = sprites.GetValue("front_default").Value<string>();
        }
        
    }
}