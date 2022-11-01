using Blog.Common;
using Blog.Model.System;
using Blog.Service.System.SystemUserService;
using Blog.WebAPI.Utility.ApiResult;
using Blog.WebAPI.Utility.JWTOption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IOptionsSnapshot<JWTOptions> _optionsSnapshot;
        private readonly ISystemUserService _systemUserService;


        public LoginController(IOptionsSnapshot<JWTOptions> optionsSnapshot, ISystemUserService systemUserService)
        {
            _optionsSnapshot = optionsSnapshot;
            _systemUserService = systemUserService;
        }
        [HttpGet]
        public async Task<ApiResult> Login(string userName, string password)
        {
            string pwd = MD5Helper.MD5Encrypt32(password);
            //后续做了user的管理后， 需要判断  加密后密码
            SystemUser data = await _systemUserService.FindAsync(u => u.Name == userName);
            if (data == null) return ApiResultHelper.Error("账户或密码错误");
            List<Claim> claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            //生成 jwt 
            string key = _optionsSnapshot.Value.SigningKey; //服务端Key
            DateTime expires = DateTime.Now.AddSeconds(_optionsSnapshot.Value.ExpireSeconds);//过期时间 
            byte[] secBytes = Encoding.UTF8.GetBytes(key);//key字符串编码
            var secKey = new SymmetricSecurityKey(secBytes);
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(claims: claims,
                expires: expires, signingCredentials: credentials);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return ApiResultHelper.Success(jwtToken); 
        }
    }
}
