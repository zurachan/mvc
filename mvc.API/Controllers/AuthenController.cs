using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc.API.Models;
using mvc.API.Models.Authen;
using mvc.API.Services;

namespace mvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenController(IAuthenService service) : ControllerBase
    {
        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        public AuthenResponse SignIn(SignInRequest model) => service.SignIn(model);

        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public Response<bool> SignUp(SignUpRequest model) => service.SignUp(model);

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
