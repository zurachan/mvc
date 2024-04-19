using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvc.Common;
using mvc.Domains;
using mvc.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login([Bind("Username,Password")] LoginModel model)
        //{
        //    if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
        //        return RedirectToAction("Error");
        //    IActionResult response = Unauthorized();

        //    var taikhoan = _context.Accounts.FirstOrDefault(x => x.Username == model.Username);

        //    if (taikhoan != null)
        //    {
        //        var password = Utils.EncryptedPassword(model.Password, taikhoan.PasswordSalt);
        //        if (taikhoan.PasswordHash == password)
        //        {
        //            var claims = new[] {
        //                new Claim(ClaimTypes.Name, model.Username),
        //                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
        //            };

        //            var roles = _context.UserRoles.Where(x => x.UserId == taikhoan.UserId).ToList();

        //            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        //            var expiry = DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:ExpiryInMinutes"]));

        //            var tokenDescriptor = new JwtSecurityToken(
        //                _config["Jwt:Issuer"],
        //                _config["Jwt:Audience"],
        //                claims,
        //                expires: expiry,
        //                signingCredentials: credentials
        //                );

        //            var generatedToken = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        //            if (generatedToken != null)
        //            {
        //                HttpContext.Session.SetString("Token", generatedToken);
        //                return RedirectToAction("Index");
        //            }
        //            else return RedirectToAction("Login");
        //        }
        //        else return RedirectToAction("Login");
        //    }
        //    else return RedirectToAction("Login");
        //}

        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login");
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}