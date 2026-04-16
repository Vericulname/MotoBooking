using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class VehicleService
    {
        private VehiclesRepos _Repos;
        private Mapper _modelmapper;
        private Mapper _requestmapper;
        public VehicleService() {
            _Repos = new VehiclesRepos();

            _modelmapper = ModelMapper<TbXe, VehiclesModel>.createMap();
            _requestmapper = ModelMapper<TbXe, VehicleRequest>.createMap();
        }

        public List<VehiclesModel> GetAll()
        {
            List<TbXe> data = _Repos.GetAll();
            List<VehiclesModel> lst = _modelmapper.Map<List<TbXe>, List<VehiclesModel>>(data);
            return lst;
        }
        public VehiclesModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy xe với id: " + id);
            }
            VehiclesModel model = _modelmapper.Map<TbXe, VehiclesModel>(data);
            return model;
        }
        public VehiclesModel Create(VehicleRequest request)
        {
            TbXe entity = _requestmapper.Map<VehicleRequest, TbXe>(request);
       
            VehiclesModel model = _modelmapper.Map<TbXe, VehiclesModel>(_Repos.Create(entity));
            return model;
        }
        public VehiclesModel UpdateStatus(int id,String status)
        {
            TbXe entity = _Repos.GetById(id);
            if (entity == null)
            {
            throw new Exception("Không tìm thấy xe với id: " + id);
              
            }

            entity.STrangThai = status;
            VehiclesModel model = _modelmapper.Map<TbXe, VehiclesModel>(_Repos.Update(entity));
            return model;
        }
        public VehiclesModel UpdateVehicle(int id, VehicleRequest request)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy xe với id: " + id);

            }
            _requestmapper.Map<VehicleRequest, TbXe>(request, data);
            VehiclesModel model = _modelmapper.Map<TbXe, VehiclesModel>(_Repos.Update(data));
            return model;
        }
        public void Delete(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy xe với id: " + id);

            }
            _Repos.Delete(id);

        }
    }
}
