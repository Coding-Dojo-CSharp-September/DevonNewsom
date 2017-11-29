using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models;
using System;
namespace dbconnection.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Users = DbConnector.Query("SELECT * FROM users;");
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            // check uniqueness of email
            if(DbConnector.Query($"SELECT id FROM users WHERE email = '{user.email}'").Count != 0)
            {
                ModelState.AddModelError("email", "Email already in use");
            }

            if(ModelState.IsValid)
            {
                // build a user with sql
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hashedpw = hasher.HashPassword(user, user.password);

                string query = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                                  VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedpw}', NOW(), NOW())";

                DbConnector.Execute(query);
                return Json(new {
                    success=true,
                    newUser=user
                });
            }
            ViewBag.Users = DbConnector.Query("SELECT * FROM users;");
            return RedirectToAction("Index");
        }
    }
}

// User person = new User{
//     first_name = "devon",
//     last_name = "newsom",
//     email = "sup@sup.com",
//     password = "asdfasdf",
//     created_at = DateTime.Now,
//     updated_at = DateTime.Now
// };

// PasswordHasher<User> hasher = new PasswordHasher<User>();
// string pw = hasher.HashPassword(person, person.password);

