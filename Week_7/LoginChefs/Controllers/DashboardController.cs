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
    public class DashboardController : Controller
    {
        public Chef LoggedChef
        {
            get { return _context.Chefs.Where( c => c.ChefId == HttpContext.Session.GetInt32("id")).FirstOrDefault(); }
        }
        private MainContext _context;
        public DashboardController(MainContext context)
        {
            _context = context;
        }
        [Route("dashboard")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") == null)
                return RedirectToAction("Index", "Chef");
        return View(InitializeDashboard());
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(Dashboard modelObj)
        {
            NewDish dish = modelObj.CreateDish;
            if(ModelState.IsValid)
            {
                Dish dishToCreate = new Dish
                {
                    Name = dish.Name,
                    ChefId = LoggedChef.ChefId
                };
                _context.Dishes.Add(dishToCreate);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", InitializeDashboard(dish));
        }
        public Dashboard InitializeDashboard(NewDish dish = null)
        {
            NewDish theDish = dish;
            if(dish == null)
                theDish = new NewDish();
            return new Dashboard
            {
                Chefs = _context.Chefs.Include(c => c.Masterpieces).ToList(),
                User = LoggedChef,
                CreateDish = theDish
            };
        }
    }
}