using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ApiFun
{
    public class Pokemon
    {
        public string Name {get;set;}
        public int Height {get;set;}
        public int Weight {get;set;}
        public List<PokeStat> Stats {get;set;}
        public Pokemon()
        {

        }
        public Pokemon(JObject data)
        {
            Stats = new List<PokeStat>();
            Name = data["name"].Value<string>();
            Height = data["height"].Value<int>();
            Weight = data["weight"].Value<int>();

            // loop through JArray of data["stats"]
            foreach(var stat in data["stats"])
            {
                Stats.Add(new PokeStat
                {
                    Name = (string)stat["stat"]["name"],
                    BaseStat = stat["base_stat"].Value<int>()

                });
            }

        }
    }
    public class PokeStat
    {
        public string Name {get;set;}
        public int BaseStat {get;set;}
    }
}