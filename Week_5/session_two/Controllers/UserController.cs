using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ModelLecture.Models;
using Microsoft.AspNetCore.Identity;

namespace ModelLecture.Controllers
{
    public class UserController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("submit")]
        public IActionResult Register(RegisterUser user)
        {
            // email is required
            string q = $"SELECT id FROM users WHERE email='{user.Email}'";
            if (DbConnector.Query(q).Count > 1)
            {
                ModelState.AddModelError("Email", "Email already in use");
            }

            if(ModelState.IsValid)
            {
                RegisterUser(user);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(HomePageUsers user)
        {
            List<Dictionary<string,object>> users = DbConnector.Query($"SELECT id, password FROM users WHERE email = '{user.Login.Email}'");

            //user exists
            if(users.Count == 0)
            {
                // we are bad
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            if(hasher.VerifyHashedPassword(user.Login, (string)users[0]["password"], user.Login.Password) == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("id", (int)users[0]["id"]);
            return RedirectToAction("Index");
        }
        public void RegisterUser(RegisterUser user)
        {
            PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
            string hashed = hasher.HashPassword(user, user.Password);

            string query = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                            VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{hashed}', NOW(), NOW())";
            DbConnector.Execute(query);

            List<Dictionary<string,object>> users = DbConnector.Query($"SELECT id FROM users WHERE email = '{user.Email}");
            HttpContext.Session.SetInt32("id", (int)users[0]["id"]);
        } 
    }
}
