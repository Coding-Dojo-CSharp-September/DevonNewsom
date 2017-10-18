using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using newChefs.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace newChefs.Controllers
{
    public class ChefController : Controller
    {
        private MainContext _context;
        public ChefController(MainContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Id = HttpContext.Session.GetInt32("id");
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(NewChef newChef)
        {
            PasswordHasher<NewChef> hasher = new PasswordHasher<NewChef>();
            if(_context.Chefs.Where(c=>c.Username == newChef.Username).SingleOrDefault() != null)
                ModelState.AddModelError("Username", "Username in use");
            if(ModelState.IsValid)
            {
                Chef chef = new Chef
                {
                    FirstName = newChef.FirstName,
                    LastName = newChef.LastName,
                    Username = newChef.Username,
                    Password = hasher.HashPassword(newChef, newChef.Password),
                    CreatedAt = DateTime.Now
                };
                Chef theChef = _context.Add(chef).Entity;
                _context.SaveChanges();

                HttpContext.Session.SetInt32("id", theChef.ChefId);
                return RedirectToAction("Index", "Dashboard");
            }
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LogChef logChef)
        {
            PasswordHasher<LogChef> hasher = new PasswordHasher<LogChef>();
            Chef chefToLog = _context.Chefs.Where(c => c.Username == logChef.LogUsername).SingleOrDefault();
            if(chefToLog == null)
                ModelState.AddModelError("LogUsername", "Invalid Username/Password");
            else if(hasher.VerifyHashedPassword(logChef, chefToLog.Password, logChef.LogPassword) == 0)
            {
                ModelState.AddModelError("LogUsername", "Invalid Username/Password");
            }
            if(!ModelState.IsValid)
                return View("Index");
            HttpContext.Session.SetInt32("id", chefToLog.ChefId);
            return RedirectToAction("Index", "Dashboard");
        }
        [HttpGet]
        [Route("chefs/{id}")]
        public IActionResult Show(int id)
        {
            Chef theChef = _context.Chefs
                .Include( chef => chef.Masterpieces )
                .Include(c => c.DishesLiked)
                    .ThenInclude(l => l.DishLiked)
                .Where(chef => chef.ChefId == id).SingleOrDefault();

            return View(theChef);
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
