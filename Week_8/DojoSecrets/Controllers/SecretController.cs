using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using DojoSecrets.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DojoSecrets.Controllers
{
    public class SecretController : Controller
    {
        private MainContext _context;
        private User ActiveUser 
        {
            get{ return _context.users.Where(u => u.user_id == HttpContext.Session.GetInt32("id")).FirstOrDefault();}
        }
        private User ActiveUserDetailed
        {
            get{ return _context.users
                .Where(u => u.user_id == HttpContext.Session.GetInt32("id"))
                .FirstOrDefault();}
        }
        public SecretController(MainContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            return View(InitialzeDashModels());
        }
        [HttpPost]
        public IActionResult Create(NewSecret nSecret)
        {
            if(ModelState.IsValid)
            {
                Secret secret = new Secret
                {
                    message = nSecret.Content,
                    user_id = ActiveUser.user_id,
                    created_at = DateTime.Now
                };
                _context.secrets.Add(secret);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", InitialzeDashModels(nSecret));
        }
        public Dashboard InitialzeDashModels(NewSecret secret = null)
        {
            NewSecret theSecret = secret == null ? new NewSecret() : secret;
            List<Secret> secrets = _context.secrets.Include(s => s.Likes).OrderBy(s => s.created_at).Take(5).ToList();

            return new Dashboard{
                AllSecrets = secrets,
                NewSecret = theSecret,
                User = ActiveUser
            };
        }
        
        
    }
}
