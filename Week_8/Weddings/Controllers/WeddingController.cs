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
    public class WeddingController : Controller
    {
        private WeddingContext _context;
        private User ActiveUser
        {
            get { return _context.Users.Where(u => u.UserId == HttpContext.Session.GetInt32("id")).FirstOrDefault();}
        }
        public WeddingController(WeddingContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        public IActionResult Index()
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewWedding model)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");

            if(ModelState.IsValid)
            {
                Wedding theWedding = new Wedding
                {
                    WedderOne = model.WedderOne,
                    WedderTwo = model.WedderTwo,
                    Date = model.Date,
                    Address = model.Address,
                    UserId = ActiveUser.UserId
                };
                _context.Weddings.Add(theWedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        
    }
}
