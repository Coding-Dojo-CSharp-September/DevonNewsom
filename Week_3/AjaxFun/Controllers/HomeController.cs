using Microsoft.AspNetCore.Mvc;
namespace AjaxFun.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }
        [Route("")]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [Route("/submit")]
        public IActionResult JsonTest(string name, string location)
        {
            User newUser = new User() 
            {
                Name=name,
                Location=location
            };

            return Json(newUser);
        }
    }
}