using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Mvc;



namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountController : ControllerBase
    {
        private readonly AuthenticationService _service;
        public AccountController() {
            _service = new AuthenticationService();
        }

        [HttpPost("CreateAccount")]
        public  IActionResult CreateAccount([FromBody] RegisterAccRequest request)
        {
            try
            {
                _service.register(request);
                return Ok("đăng ký tài khoản thành công");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        
        [HttpPut("AssignRole")]
        public  IActionResult AssignRole([FromHeader] int id, [FromHeader] string role )
        {
            try
            {
                _service.UpdateRole(id, role);
                return Ok("cập nhật vai trò thành công");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete("Delete")]
        public  IActionResult DeleteAccount([FromHeader] int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("cập nhật vai trò thành công");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
