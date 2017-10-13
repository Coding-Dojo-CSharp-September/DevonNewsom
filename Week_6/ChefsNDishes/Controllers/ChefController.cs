using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsNDishes.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class ChefController : Controller
    {
        private ChefzContext _context;
        public ChefController(ChefzContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            GimmeTheBag();
            return View();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(NewChef chef2Make)
        {
            if(_context.Chefs.Where( chef => chef.Username == chef2Make.Username).SingleOrDefault() != null)
            {
                ModelState.AddModelError("Username", "Username Exists");
            }
            if(ModelState.IsValid)
            {
                Chef newChef = new Chef
                {
                    FirstName = chef2Make.FirstName,
                    LastName = chef2Make.LastName,
                    Username = chef2Make.Username,
                    CreatedAt = DateTime.Now
                };
                _context.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            GimmeTheBag();
            return View("Index", chef2Make);
        }
        [HttpGet]
        [Route("{chef_id}")]
        public IActionResult Show(int chef_id)
        {
            Chef theChef = _context.Chefs.Include( chef => chef.Masterpieces ).Where(chef => chef.ChefId == chef_id).SingleOrDefault();
            return View(theChef);
        }
        public void GimmeTheBag()
        {

            ViewBag.Chefs = _context.Chefs.ToList();
        }
    }
}
