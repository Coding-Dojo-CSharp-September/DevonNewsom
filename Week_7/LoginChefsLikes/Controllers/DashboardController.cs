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
        [Route("like/{dish_id}")]
        public IActionResult Like(int dish_id)
        {
            Like like = new Like
            {
                ChefId = LoggedChef.ChefId,
                DishId = dish_id
            };
            _context.Likes.Add(like);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("unlike/{dish_id}")]
        public IActionResult Unlike(int dish_id)
        {
            Like like = _context.Likes
                .Where(l => l.ChefId == LoggedChef.ChefId)
                .Where(d => d.DishId == dish_id)
                .SingleOrDefault();

            _context.Likes.Remove(like);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public Dashboard InitializeDashboard(NewDish dish = null)
        {
            NewDish theDish = dish;
            if(dish == null)
                theDish = new NewDish();

            List<Dish> userHasLiked = _context.Likes
                .Where( l => l.ChefId == LoggedChef.ChefId)
                .Select( d => d.DishLiked).ToList();

            List<Dish> userHasNotLiked = _context.Dishes
                .Except(userHasLiked).ToList();
            
            
            return new Dashboard
            {
                Chefs = _context.Chefs.ToList(),
                User = LoggedChef,
                CreateDish = theDish,
                LikedDishes = userHasLiked,
                NotLikedDishes = userHasNotLiked
            };
        }
    }
}