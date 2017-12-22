using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Secrets.Models;
using System.Linq;

namespace Secrets.Controllers
{
    public class DashboardController : Controller
    {
        private User LoggedUser 
        {
            get { return _context.users.SingleOrDefault(u => u.user_id == HttpContext.Session.GetInt32("id")); }
        }
        private MyContext _context;
        public DashboardController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Index()
        {
            DashboardModel model = new DashboardModel()
            {
                User = LoggedUser,
                Secrets = _context.secrets
                    .Include(s => s.Likes)
                        .ThenInclude(l => l.Liker)
                    .Include(s => s.Creator).ToList(),
                NewSecret = new Secret()
            };
            return View(model);
        }

        [HttpPost("secret/create")]
        public IActionResult Create(DashboardModel model)
        {
            Secret newSecret = model.NewSecret;
            if(ModelState.IsValid)
            {
                newSecret.created_at = DateTime.Now;
                newSecret.user_id = LoggedUser.user_id;
                _context.secrets.Add(newSecret);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            model.User = LoggedUser;
            model.Secrets = _context.secrets.ToList();
            return View("Index", model);
        }
        [HttpGet("secret/delete/{secret_id}")]
        public IActionResult Delete(int secret_id)
        {
            // check secret for toDelete.user_id == LoggedUser.user_id
            Secret toDelete = _context.secrets.SingleOrDefault(s => s.secret_id == secret_id);
            if(toDelete.user_id == LoggedUser.user_id)
            {
                _context.secrets.Remove(toDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("like/{secret_id}")]
        public IActionResult Like(int secret_id)
        {
            Like theLike = new Like()
            {
                user_id = LoggedUser.user_id,
                secret_id = secret_id
            };
            _context.likes.Add(theLike);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}