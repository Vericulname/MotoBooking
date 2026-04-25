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
    public class InvoicesController : ControllerBase
    {
        private InvoicesService _service;
        public InvoicesController() {
            _service = new InvoicesService();
        }
        [HttpGet]
        [Route("getall")]

        public IActionResult GetAllOrders()
        {
            List<InvoiceModel> orders = _service.GetAll();
            return Ok(orders);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("Getbyid")]
        public IActionResult GetOrderByid([FromHeader]int id) {
            try
            {
                InvoiceModel order = _service.GetById(id);
                return Ok(order);
            }
            catch (Exception ex) { 
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]InvoiceRequest request) {
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
        public IActionResult Update([FromHeader]int id,[FromBody]InvoiceRequest request) {

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
        [Route("delete")]
        public IActionResult delete([FromHeader]int id) {
            try
            {
                _service.Delete(id);
                return Ok("xoá thành công hoá đơn");
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

    }
}
