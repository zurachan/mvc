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
        [Route("getmenu")]
        public List<Menu> GetMenu() => service.GetMenu();

        [HttpPost]
        [Route("savemenu")]
        public Menu SaveMenu(Menu model) => service.SaveMenu(model);
    }
}
