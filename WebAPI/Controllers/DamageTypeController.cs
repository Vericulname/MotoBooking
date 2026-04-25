using BussinessLayer.Models;
using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "NotCustomer")]
    public class DamageTypeController : ControllerBase
    {
        private readonly DamageTypesService _service;

        public DamageTypeController()
        {
            _service = new DamageTypesService();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<DamageTypesModel> result = _service.GetAll();

            return Ok(result);

        }
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetById([FromHeader]int id)
        {
            try
            {
                DamageTypesModel result = _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(DamageTypesModel request)
        {
        
            return Ok(_service.Create(request));
        }
        [HttpPut]
        [Route("Update")]
        public ActionResult Update([FromHeader] int id, [FromBody] DamageTypesModel request)
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
        [Route("Delete")]
        public ActionResult Delete([FromHeader]int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("xoá thành công loại hư hỏng với id: " + id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
