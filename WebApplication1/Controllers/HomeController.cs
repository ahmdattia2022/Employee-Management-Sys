using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Basic cards
        public IActionResult Basic() 
        { 
            return View(); 
        }
    }
}
