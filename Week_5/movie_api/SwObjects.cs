// using System;
// using System.Collections.Generic;
// using Newtonsoft.Json.Linq;

// namespace api
// {
//     public abstract class SwObject 
//     {
//         public string Url { get; set; }

//         public static SwObject SwFromJson(JObject data, string type)
//         {
//             switch(type)
//             {
//                 case "people":
//                     //JToken FilmData = data["films"].Value<JArray>();
//                     //List<Film> FilmList = new List<Film>();
//                     // foreach(JToken filmUri in FilmData)
//                     // {
//                     //     string url = filmUri.Value<string>();
//                     //     string [] subst = url.Split('/');
//                     //     for(int i = 0; i < subst.Length; i++)
//                     //     {
//                     //         if(subst[i] == "films")
//                     //         {
//                     //             Film filmObj = new Film();
//                     //             WebRequest.GetStarwarsDataAsync("films", Int32.Parse(subst[i+1]), response => {
//                     //                 filmObj = response as Film;
//                     //                 FilmList.Add(filmObj);
//                     //             }).Wait();
//                     //         }
//                     //         break;
//                     //     }
//                     // }
//                     return new Person{
//                         Name = data["name"].Value<string>(),
//                         Height = data["height"].Value<int>(),
//                         Mass = data["mass"].Value<int>(),
//                         HairColor = data["hair_color"].Value<string>(),
//                         SkinColor = data["skin_color"].Value<string>(),
//                         Birthyear = data["birth_year"].Value<string>(),
//                         //Films = FilmList
//                     };
//                 default:
//                     // JToken CharData = data["characters"].Value<JArray>();
//                     // List<Person> CharList = new List<Person>();
//                     // foreach(JToken filmUri in CharData)
//                     // {
//                     //     string url = filmUri.Value<string>();
//                     //     string [] subst = url.Split('/');
//                     //     for(int i = 0; i < subst.Length; i++)
//                     //     {
//                     //         if(subst[i] == "characters")
//                     //         {
//                     //             Person charObj = new Person();
//                     //             WebRequest.GetStarwarsDataAsync("people", Int32.Parse(subst[i+1]), response => {
//                     //                 charObj = response as Person;
//                     //                 CharList.Add(charObj);
//                     //             }).Wait();
//                     //         }
//                     //         break;
//                     //     }
//                     // }
//                     return new Film{
//                         Title = data["title"].Value<string>(),
//                         ReleaseDate = data["release_date"].Value<DateTime>(),
//                         //Characters = CharList
//                     };
//             }
//         }
//     }
//     public class Person : SwObject
//     {
//         public string Name { get; set; }
//         public int Height { get; set; }
//         public int Mass { get; set; }
//         public string HairColor { get; set; }
//         public string SkinColor { get; set; }
//         public string Birthyear { get; set; }
//         //public List<Film> Films { get; set; }
//     }
//     public class Film : SwObject
//     {
//         public string Title { get; set; }
//         public DateTime ReleaseDate { get; set; }
//         //public List<Person> Characters { get; set; }
//     }
// }