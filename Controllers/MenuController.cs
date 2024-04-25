using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Domains;
using mvc.Services;

namespace mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController(IMenuService service) : ControllerBase
    {
        [HttpPost]
        [Route("controller")]
        public List<AppController> GetMenu()
        {
            return service.GetMenu();
        }
    }
}
