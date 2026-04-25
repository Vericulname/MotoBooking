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
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _service;
        public VehiclesController()
        {
            _service = new VehicleService();
        }

        [HttpGet]
        [Route("GetAllVehicle")]
        
        public IActionResult GetAll()
        {
            List<VehiclesModel> vehicles = _service.GetAll();
            return Ok(vehicles);
        }
        [HttpGet]
        [Route("GetVehicleById/{id}")]
        public IActionResult GetById(int id)
        {   try
            {
                VehiclesModel vehicle = _service.GetById(id);
                return Ok(vehicle);
            }
            catch (Exception ex) {
                return NotFound(ex.Message);
            }
        }
        //[HttpGet]
        //[Route("GetVehicleByName/{name}")]
        //public IActionResult GetByName(string name)
        //{
        //    try
        //    {
        //        VehiclesModel vehicle = _service.GetById(id);
        //        return Ok(vehicle);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
        [HttpPost]
        [Route("AddVehicle")]
        [Authorize(policy:"NotCustomer")]
        public IActionResult AddVehicle(VehicleRequest request)
        {

            VehiclesModel result = _service.Create(request);
            return Ok(result);

        }
        [HttpPut]
        [Route("UpdateStatus/{id}")]
        [Authorize(policy: "NotCustomer")]
        public IActionResult UpdateStatus(int id, String status)
        {
            try
            {
                VehiclesModel result = _service.UpdateStatus(id, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateVehicle/{id}")]
        [Authorize(policy: "NotCustomer")]
        public IActionResult UpdateVehicle(int id, VehicleRequest request)
        {
            try
            {
                VehiclesModel result = _service.UpdateVehicle(id, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        [Authorize(policy: "NotCustomer")]
        [Route("DeleteVehicle/{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("xoá thành công xe với id: " + id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
