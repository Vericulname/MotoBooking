using BussinessLayer.Models;
using BussinessLayer.request;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly TbKhachHangService _service;

        public KhachHangController()
        {
            _service = new TbKhachHangService();
        }

        [HttpGet]
        [Route("GetAllKhachHang")]
        public IActionResult GetAllKhachHang()
        {
            List<TbKhachHangModel> result = _service.GetAll();

            return Ok(result);

        }
        [HttpGet]
        [Route("GetKhachHangById")]
        public ActionResult GetKhachHangById(int id)
        {
            try
            {
                TbKhachHangModel result = _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        [HttpPost]
        [Route("CreateKhachHang")]
        public ActionResult CreateKhachHang(KhachHangRequest request)
        {
        
            return Ok(_service.Create(request));
        }
        [HttpPut]
        [Route("UpdateKhachHang")]
        public ActionResult UpdateKhachHang([FromHeader] int id, [FromBody] KhachHangRequest request)
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
        [Route("DeleteKhachHang")]
        public ActionResult DeleteKhachHang(int id)
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
