using Microsoft.AspNetCore.Mvc;

namespace mvc.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}