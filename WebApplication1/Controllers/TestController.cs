using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }
        //---------------------------Ajax call------------------
        // --------------------- Ajax Call -------------

        [HttpPost]
        public JsonResult Display(string name)
        {
            var data = "Welcome : " + name;
            return Json(data);
        }
    }
}
