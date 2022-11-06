using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Basicinfo.Controllers
{
    [Area("Basicinfo")]
    public class inventoryDefinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
