using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BussinessLayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly AuthenticationService _service;
        private readonly IConfiguration _configuration;
        public AuthenticationsController( IConfiguration configuration)
        {
            _service = new AuthenticationService();
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginAccRequest request)
        {
            try
            {
                var user = _service.login(request);
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDecriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.MobilePhone,user.SSoDienThoai),
                    new Claim(ClaimTypes.Role,user.SVaiTro!)
                }),
                    Expires = DateTime.Now.AddMinutes(Double.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDecriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { token = tokenString, role = user.SVaiTro });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          

        }
        [HttpPost("Register")]
        
        public IActionResult Register([FromBody] RegisterCustomerRequest request)
        {

            try
            {
                _service.registerCustomer(request);
                return Ok("đăng ký thành công");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
      
    }
}
