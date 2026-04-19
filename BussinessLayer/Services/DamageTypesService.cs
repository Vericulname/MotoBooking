using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;

namespace BussinessLayer.Services
{
    public class DamageTypesService
    {
        private DamageTypeRepos _Repos;
        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public DamageTypesService()
        {
            _Repos = new DamageTypeRepos();
            _modelmapper = ModelMapper<TblLoaiHuHong, DamageTypesModel>.createMap();

        }
        public List<DamageTypesModel> GetAll()
        {
            List<TblLoaiHuHong> data = _Repos.GetAll();
            List<DamageTypesModel> lst = _modelmapper.Map<List<DamageTypesModel>>(data);
            return lst;
        }
        public DamageTypesModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với id: " + id);
            }
            DamageTypesModel model = _modelmapper.Map<DamageTypesModel>(data);
            return model;
            
        }
      
        public DamageTypesModel Create(DamageTypesModel model)
        {
            var data = _modelmapper.Map<TblLoaiHuHong>(model);
            
            return _modelmapper.Map<DamageTypesModel>(_Repos.Add(data));
        }
        public DamageTypesModel Update(int id,DamageTypesModel model)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy khách hàng với id: " + id);

            }
            data = _modelmapper.Map<TblLoaiHuHong>(model);
            return _modelmapper.Map<DamageTypesModel>(_Repos.Update(data));
        }
        public void Delete(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với id: " + id);
            }
            _Repos.Delete(id);
        }
    }
}
