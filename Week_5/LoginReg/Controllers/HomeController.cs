using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using dbconnection.Models;
using System.Collections.Generic;
using System;
namespace dbconnection.Controllers
{
    public class HomeController : Controller
    {
        private bool EmailIsUnique(string email)
        {
            return DbConnector.Query($"SELECT id FROM users WHERE email = '{email}'").Count == 0;
        }
        private HomePage GetUsers(LogUser logUser = null, RegUser regUser = null)
        {
            return new HomePage()
            {
                Users = DbConnector.Query("SELECT * FROM users"),
                logUser = logUser == null ? new LogUser() : logUser,
                regUser = regUser == null ? new RegUser() : regUser
            };
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(GetUsers());
        }
        [HttpPost("register")]
        public IActionResult Register(RegUser user)
        {
            // check uniqueness of email
            if(!EmailIsUnique(user.email))
            {
                ModelState.AddModelError("email", "Email already in use");
            }

            if(ModelState.IsValid)
            {
                // build a user with sql
                PasswordHasher<RegUser> hasher = new PasswordHasher<RegUser>();
                string hashedpw = hasher.HashPassword(user, user.password);

                string query = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                                  VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedpw}', NOW(), NOW())";

                DbConnector.Execute(query);
                return Json(new {
                    success=true,
                    newUser=user
                });
            }
            return View("Index", GetUsers(null, user));
        }
        [HttpPost("login")]
        public IActionResult Login(LogUser user)
        {
            // Check email in DB for an existing email
            if(EmailIsUnique(user.log_email))
            {
                ModelState.AddModelError("log_email", "Invalid Email/Password");
            }
            else
            {
                // check password
                // query password with submitted email
                string hashed = (string)DbConnector.Query($"SELECT password FROM users WHERE email='{user.log_email}'")[0]["password"];

                //check password with password hasher
                PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();

                // check result of verify against 0 for failure!
                if(hasher.VerifyHashedPassword(user, hashed, user.log_password) == 0)
                {
                    ModelState.AddModelError("log_email", "Invalid Email/Password");
                }

            }

            if(ModelState.IsValid)
            {
                return Json(new {
                    success=true,
                    newUser=user
                });
            }
            return View("Index", GetUsers(user, null));
        }
    }
}

