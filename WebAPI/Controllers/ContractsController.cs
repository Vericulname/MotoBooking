using BussinessLayer.Models;
using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "NotCustomer")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private ContractsService _service;
        public ContractsController() {
            _service = new ContractsService();
        }
        [HttpGet]
        [Route("getall")]

        public IActionResult GetAllOrders()
        {
            List<ContractsModel> orders = _service.GetAll();
            return Ok(orders);
        }
        [HttpGet]
        [Route("Getbyid")]
        [AllowAnonymous]
        public IActionResult GetOrderByid([FromHeader]int id) {
            try
            {
                ContractsModel order = _service.GetById(id);
                return Ok(order);
            }
            catch (Exception ex) { 
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]ContractsRequest request) {
            try
            {
                return Ok(_service.Create(request));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("Update")]
        [Authorize(Policy = "NotCustomer")]
        public IActionResult Update([FromHeader]int id,[FromBody]ContractsRequest request) {

            try
            {
                return Ok(_service.Update(id, request));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Authorize(Policy = "NotCustomer")]
        [Route("delete")]
        public IActionResult delete([FromHeader]int id) {
            try
            {
                _service.Delete(id);
                return Ok("xoá thành công đơn đặt xe");
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

    }
}
