using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;

namespace BussinessLayer.Services
{
    public class EmployeesService
    {
        private EmployeesRepos _Repos;
        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public EmployeesService()
        {
            _Repos = new EmployeesRepos();
       
            _modelmapper = ModelMapper<TbNhanvien, EmployeesModel>.createMap();
            _requestmapper = ModelMapper<TbNhanvien, EmployeesRequest>.createMap();
        }
        public List<EmployeesModel> GetAll()
        {
            List<TbNhanvien> data = _Repos.GetAll();
            List<EmployeesModel> lst = _modelmapper.Map<List<TbNhanvien>, List<EmployeesModel>>(data);
            return lst;
        }
        public EmployeesModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy nhân viên với id: " + id);
            }
            EmployeesModel model = _modelmapper.Map<TbNhanvien, EmployeesModel>(data);
            return model;
            
        }
       
        public EmployeesModel Create(EmployeesRequest request)
        {
            TbNhanvien data = _requestmapper.Map<EmployeesRequest, TbNhanvien>(request);
            
            return _modelmapper.Map<TbNhanvien, EmployeesModel>(_Repos.Add(data));
        }
        public EmployeesModel Update(int id,EmployeesRequest request)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy nhân viên với id: " + id);

            }
            _requestmapper.Map<EmployeesRequest, TbNhanvien>(request, data);
            return _modelmapper.Map<TbNhanvien, EmployeesModel>(_Repos.Update(data));
        }
        public EmployeesModel UpdateRole(int id, String role)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {

                throw new Exception("Không tìm thấy nhân viên với id: " + id);

            }
            data.SVaiTro = role;
            return _modelmapper.Map<TbNhanvien, EmployeesModel>(_Repos.Update(data));
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
