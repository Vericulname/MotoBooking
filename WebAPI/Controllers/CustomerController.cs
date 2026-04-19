using BussinessLayer.Models;
using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomersService _service;

        public CustomerController()
        {
            _service = new CustomersService();
        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            List<CustomerModel> result = _service.GetAll();

            return Ok(result);

        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public ActionResult GetCustomerById(int id)
        {
            try
            {
                CustomerModel result = _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }
        [HttpGet]
        [Route("GetCustomerByName{name}")]
        public ActionResult GetCustomerByName(string name)
        {
            try
            {
                CustomerModel result = _service.GetByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        [HttpPost]
        [Route("CreateCustomer")]
        public ActionResult CreateCustomer(CustomerRequest request)
        {
        
            return Ok(_service.Create(request));
        }
        [HttpPut]
        [Route("UpdateCustomer/{id}")]
        public ActionResult UpdateCustomer([FromHeader] int id, [FromBody] CustomerRequest request)
        {
            try
            {
                return Ok(_service.Update(id, request));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("xoá thành công khách hàng với id: " + id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
