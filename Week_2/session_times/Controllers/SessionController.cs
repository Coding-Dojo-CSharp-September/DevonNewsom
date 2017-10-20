using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace session_times.Controllers
{
    public class SessionController : Controller
    {
        public int? TheNumber
        {
            get{ return HttpContext.Session.GetInt32("number");}
        }
        public string TheMessage
        {
            get{ return HttpContext.Session.GetString("message");}
        }
        // localhost:5000
        // localhost:5000/session
        // localhost:5000/session/index
        public IActionResult Index()
        {
            if(TheNumber == null)
                SetRandomNumber();
            if(TheMessage != null)
                ViewBag.Message = TheMessage;

            ViewBag.Number = TheNumber;
            return View();
        }
        public void SetRandomNumber()
        {
            Random rand = new Random();
            HttpContext.Session.SetInt32("number", rand.Next(100));
        }
        // localhost:5000/session/guess

        [HttpPost]
        public IActionResult Guess(int guess)
        {
            string theMessage;
            if(guess < TheNumber)
            {
                theMessage = "too low";
            }
            else if(guess > TheNumber)
            {
                theMessage = "too high";
            }
            else
            {
                theMessage = "you win";
            }
            HttpContext.Session.SetString("message", theMessage);
            return RedirectToAction("Index");
        }
        // localhost:5000/session/reset
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
