using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class TaiChinhController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
