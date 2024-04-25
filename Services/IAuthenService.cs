using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvc.Common;
using mvc.Domains;
using mvc.Models.Authen;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mvc.Services
{
    public interface IAuthenService
    {
        AuthenResponse Login(AuthenRequest request);
    }

    public class AuthenSerice(AppDbContext context, IConfiguration config) : IAuthenService
    {
        public AuthenResponse Login(AuthenRequest request)
        {
            AuthenResponse result = new AuthenResponse();
            var taikhoan = context.Accounts.Include(x => x.User).FirstOrDefault(x => x.Username == request.Username);
            if (taikhoan != null)
            {
                var password = Utils.EncryptedPassword(request.Password, taikhoan.PasswordSalt);
                if (taikhoan.PasswordHash == password)
                {
                    var claims = new[] {
                            new Claim(ClaimTypes.Name, request.Username),
                            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                        };

                    var roles = context.UserRoles.Include(x => x.Role)
                        .Where(x => x.UserId == taikhoan.UserId).Select(x => x.Role).ToList();

                    var menu = context.RoleControllers.Include(x => x.Controller)
                        .Where(x => roles.Contains(x.Role)).Select(x => x.Controller).OrderBy(x => x.Id).ToList();

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                    var expiry = DateTime.Now.AddMinutes(Convert.ToInt32(config["Jwt:ExpiryInMinutes"]));

                    var tokenDescriptor = new JwtSecurityToken(
                        config["Jwt:Issuer"],
                        config["Jwt:Audience"],
                        claims,
                        expires: expiry,
                        signingCredentials: credentials
                        );

                    var generatedToken = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                    if (generatedToken != null)
                    {
                        result.Token = generatedToken;
                        result.Menu = menu;
                        result.User = taikhoan.User;
                    }
                    else result.Message = "Tạo token không thành công";
                }
                else result.Message = "Sai mật khẩu";
            }
            else result.Message = "Tài khoản không tồn tại";

            return result;
        }
    }
}
