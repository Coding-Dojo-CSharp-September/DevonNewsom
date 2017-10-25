using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Weddings.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return View(InitializeDashboard());
        }
        public IActionResult New()
        {
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
        public IActionResult RSVP(int id)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            RSVP rsvp = new RSVP
            {
                UserId = ActiveUser.UserId,
                WeddingId = id
            };
            _context.RSVPs.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UnRSVP(int id)
        {
            if(ActiveUser == null)
                return RedirectToAction("Index", "Home");
            RSVP rsvp = _context.RSVPs.Where(r => r.UserId == ActiveUser.UserId)
                                      .Where(r => r.WeddingId == id)
                                      .SingleOrDefault();

            _context.RSVPs.Remove(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public DashboardModels InitializeDashboard()
        {
            List<Wedding> yourWeddings = _context.RSVPs.Where(r => r.UserId == ActiveUser.UserId)
                                                       .Select(r => r.Wedding).ToList();
            List<Wedding> otherWeddings = _context.Weddings.Except(yourWeddings).ToList();
            return new DashboardModels
            {
                AllWeddings = _context.Weddings.Include(w => w.Guests).ToList(),
                User = ActiveUser,
                YourWeddings = yourWeddings,
                OtherWeddings = otherWeddings
            
            };
        }
    }
}
