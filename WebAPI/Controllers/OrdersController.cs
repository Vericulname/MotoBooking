using BussinessLayer.Models;
using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderService _service;
        public OrdersController() {
            _service = new OrderService();
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllOrders()
        {
            List<OrdersModel> orders = _service.GetAll();
            return Ok(orders);
        }
        [HttpGet]
        [Route("Getbyid")]
        public IActionResult GetOrderByid([FromHeader]int id) {
            try
            {
                OrdersModel order = _service.GetById(id);
                return Ok(order);
            }
            catch (Exception ex) { 
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]OrdersRequest request) {
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
        public IActionResult Update([FromHeader]int id,[FromBody]OrdersRequest request) {

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
                return Ok("xoá thành công đơn đặt xe");
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

    }
}
