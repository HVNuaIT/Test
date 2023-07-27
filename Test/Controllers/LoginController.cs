using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly Database db;
        private readonly ApiSetting _setting;
     
        private readonly IConfiguration _configuration;
        public LoginController( Database _db, IOptionsMonitor<ApiSetting> options, IConfiguration configuration) { db = _db; _setting = options.CurrentValue; _configuration = configuration; }

        [HttpPost("Login")]

        public async Task<ActionResult<string>> LoginUser(Login user)
        {
            var check = db.Users.FirstOrDefault(a => a.Email == user.Email);
            var checkrole = db.Roles.FirstOrDefault(x => x.Id == check.maQuyen);
            if(check !=null && checkrole.Name==user.Role&& BCrypt.Net.BCrypt.Verify(user.Password,check.Password))
            {
                var token = CreateToken(check);
                //var refreshToken = GenerateRefreshToken();
                SetRefreshToken(token);
                return Ok(token);
            }

            return Unauthorized();
        }
       
        private void SetRefreshToken(string newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(46),
            };
            Response.Cookies.Append("jwtCookie", newRefreshToken, cookieOptions);


        }

        private string CreateToken(User user)
        {
            var check = db.Roles.FirstOrDefault(x => x.Id == user.maQuyen);
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role,check.Name),
                new Claim(ClaimTypes.Email, user.Email),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSetting:SecretKey").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        [HttpPost("Logout")]
        public async Task<ActionResult<string>> Logout()
        {
            Response.Cookies.Delete("jwtCookie");
            return Ok("Da Dang Xuat");
        }

        #region
        //private RefreshToken GenerateRefreshToken()
        //{
        //    var refreshToken = new RefreshToken
        //    {
        //        Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
        //        Expires = DateTime.Now.AddDays(7),
        //        Created = DateTime.Now
        //    };

        //    return refreshToken;
        //}
        //[HttpPost("refresh-token")]
        //public async Task<ActionResult<string>> RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];

        //    if (!user.RefreshToken.Equals(refreshToken))
        //    {
        //        return Unauthorized("Invalid Refresh Token.");
        //    }
        //    else if (user.TokenExpires < DateTime.Now)
        //    {
        //        return Unauthorized("Token expired.");
        //    }

        //    string token = CreateToken(user);
        //    var newRefreshToken = GenerateRefreshToken();
        //    SetRefreshToken(newRefreshToken);

        //    return Ok(token);
        //}

        //private string CreateToken(User taiKhoan)
        //{

        //    List<Claim> tokens = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name,taiKhoan.Name),
        //        new Claim(ClaimTypes.Role,taiKhoan.VaiTro)
        //    };
        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:SecretKey").Value));
        //    var cre = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        //    var token = new JwtSecurityToken(
        //        claims: tokens,
        //        expires: DateTime.Now.AddDays(1),
        //        signingCredentials: cre
        //        );

        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;
        //}
        #endregion
    }
}
