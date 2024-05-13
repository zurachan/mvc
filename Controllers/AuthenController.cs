using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.Models.Authen;
using mvc.Services;

namespace mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenController(IAuthenService service) : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public AuthenResponse Login(AuthenRequest model) => service.Login(model);

        [HttpPost]
        [Route("Test")]
        public string Test()
        {
            var user = HttpContext.User;
            var name = user.Claims.FirstOrDefault()?.Value;

            return "Test done! with user: " + name;
        }
    }
}
