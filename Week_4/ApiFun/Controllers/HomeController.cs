using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace ApiFun.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Pokemon pokemon = new Pokemon();
            WebRequest.GetPokemonDataAsync(39, poke => {
                pokemon = poke;
            }).Wait();

            ViewBag.Poke = pokemon;

            return View();
        }
    }
}