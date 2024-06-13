using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.API.Services;
using mvc.Domain;

namespace mvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController(IMenuService service) : ControllerBase
    {
        [HttpPost]
        [Route("getmenu")]
        public List<Menu> GetMenu()
        {
            return service.GetMenu();
        }

        [HttpPost]
        [Route("savemenu")]
        public Menu SaveMenu(Menu model) => service.SaveMenu(model);
    }
}
