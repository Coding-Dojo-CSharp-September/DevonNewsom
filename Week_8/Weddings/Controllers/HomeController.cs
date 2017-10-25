using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Weddings.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Weddings.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _context;
        private User ActiveUser
        {
            get { return _context.Users.Where(u => u.UserId == HttpContext.Session.GetInt32("id")).FirstOrDefault();}
        }
        public HomeController(WeddingContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(RegisterUser model)
        {
            if(_context.Users.Where(u => u.Email == model.Email).FirstOrDefault() != null)
                ModelState.AddModelError("Email", "Email in use!");
            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
                User theUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = hasher.HashPassword(model, model.Password)
                };
                User newUser = _context.Users.Add(theUser).Entity;
                _context.SaveChanges();

                HttpContext.Session.SetInt32("id", newUser.UserId);
                return RedirectToAction("Index", "Wedding");
            }
            return View("Index");
        }
        public IActionResult Login(LoginUser model)
        {
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            User checkUser = _context.Users.Where(u => u.Email == model.LogEmail).FirstOrDefault();
            if(checkUser == null)
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
            else if(hasher.VerifyHashedPassword(model, checkUser.Password, model.LogPassword) == 0)
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");

            if(ModelState.IsValid)
            {
                HttpContext.Session.SetInt32("id", checkUser.UserId);
                return RedirectToAction("Index", "Wedding");
            }
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
