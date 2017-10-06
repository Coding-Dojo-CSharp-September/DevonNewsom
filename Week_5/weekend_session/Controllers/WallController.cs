using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ModelLecture.Models;

namespace ModelLecture.Controllers
{
    public class WallController : Controller
    {
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("messages/create")]
        public IActionResult CreateMessage(Message message)
        {
            if(ModelState.IsValid)
            {
                // insert a message
                string query = $@"INSERT INTO messages (content, user_id, created_at, updated_at)
                                  VALUES ('{message.Content}', {(int)HttpContext.Session.GetInt32("id")}, NOW(), NOW())";
                return RedirectToAction("Index");
            }
            return View("Index");
        }

    }

}
