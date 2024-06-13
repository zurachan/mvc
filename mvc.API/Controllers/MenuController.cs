using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Domains;
using mvc.Repository;
using mvc.Services;

namespace mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController(IMenuService service) : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        [HttpPost]
        [Route("getmenu")]
        public List<Menu> GetMenu()
        {
            var menu = unitOfWork.MenuRepository.Get();

            return service.GetMenu();
        }

        [HttpPost]
        [Route("savemenu")]
        public Menu SaveMenu(Menu model) => service.SaveMenu(model);
    }
}
