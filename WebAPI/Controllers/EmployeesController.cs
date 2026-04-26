using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "manager")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesService _service;
        public EmployeesController()
        {
            _service = new EmployeesService();
        }

        [HttpGet]

        [Route("GetAllEmployees")]
        public IActionResult GetAll()
        {
            var employees = _service.GetAll();
            return Ok(employees);
        }
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var employee = _service.GetById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult Create(RegisterAccRequest request)
        {
            try
            {
                var employee = _service.Create(request);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult Update(int id, EmployeesRequest request)
        {
            try
            {
                var employee = _service.Update(id, request);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateEmployeeRole/{id}")]
        public IActionResult UpdateRole(int id, String role)
        {
            try
            {
                var employee = _service.UpdateRole(id, role);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Xóa nhân viên thành công");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
