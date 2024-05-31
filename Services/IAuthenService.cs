﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvc.Common;
using mvc.Domains;
using mvc.Models;
using mvc.Models.Authen;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mvc.Services
{
    public interface IAuthenService
    {
        AuthenResponse SignIn(SignInRequest request);

        ResultModel<bool> SignUp(SignUpRequest request);
    }

    public class AuthenSerice(AppDbContext context, IConfiguration config) : IAuthenService
    {
        public AuthenResponse SignIn(SignInRequest request)
        {
            AuthenResponse result = new AuthenResponse();
            var taikhoan = context.Account.Include(x => x.User).FirstOrDefault(x => x.Username == request.Username);
            if (taikhoan != null)
            {
                var password = Utils.EncryptedPassword(request.Password, taikhoan.PasswordSalt);
                if (taikhoan.PasswordHash == password)
                {
                    var claims = new[] {
                            new Claim(ClaimTypes.Name, request.Username),
                            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                        };

                    var roles = context.UserRole.Include(x => x.Role)
                        .Where(x => x.UserId == taikhoan.UserId).Select(x => x.Role).ToList();

                    var menu = context.RoleMenu.Include(x => x.Menu).ThenInclude(x => x.Children)
                        .Where(x => roles.Contains(x.Role)).Select(x => x.Menu).OrderBy(x => x.Id).ToList();

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

        public ResultModel<bool> SignUp(SignUpRequest request)
        {
            var dbAccount = context.Account.FirstOrDefault(x => x.Username == request.Username);
            if (dbAccount == null)
            {
                var user = new User() { FullName = request.Fullname };
                context.User.Add(user);

                var salt = Guid.NewGuid().ToString();
                var account = new Account()
                {
                    Username = request.Username,
                    PasswordHash = Utils.EncryptedPassword(request.Password, salt),
                    PasswordSalt = salt,
                    User = user,
                };
                context.Account.Add(account);
                context.SaveChanges();
                return new ResultModel<bool>(true);
            }
            else return new ResultModel<bool>(ErrorType.DUPLICATED, "Tài khoản đã tồn tại");
        }
    }
}
