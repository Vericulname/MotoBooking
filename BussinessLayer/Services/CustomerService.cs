using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;

namespace BussinessLayer.Services
{
    public class CustomersService
    {
        private CustomersRepos _Repos;
        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public CustomersService()
        {
            _Repos = new CustomersRepos();
            _modelmapper = ModelMapper<TblKhachhang, CustomerModel>.createMap();
            _requestmapper = ModelMapper<TblKhachhang, CustomerRequest>.createMap();
        }
        public List<CustomerModel> GetAll()
        {
            List<TblKhachhang> data = _Repos.GetAll();
            List<CustomerModel> lst = _modelmapper.Map<List<TblKhachhang>, List<CustomerModel>>(data);
            return lst;
        }
        public CustomerModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với id: " + id);
            }
            CustomerModel model = _modelmapper.Map<TblKhachhang, CustomerModel>(data);
            return model;
            
        }
        public CustomerModel GetByName(string name)
        {
            var data = _Repos.GetByName(name);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với tên: " + name);
            }
            CustomerModel model = _modelmapper.Map<TblKhachhang, CustomerModel>(data);
            return model;

        }
        public CustomerModel Create(CustomerRequest request)
        {
            TblKhachhang data = _requestmapper.Map<CustomerRequest, TblKhachhang>(request);
            
            return _modelmapper.Map<TblKhachhang, CustomerModel>(_Repos.Add(data));
        }
        public CustomerModel Update(int id,CustomerRequest request)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy khách hàng với id: " + id);

            }
            _requestmapper.Map<CustomerRequest, TblKhachhang>(request, data);
            return _modelmapper.Map<TblKhachhang, CustomerModel>(_Repos.Update(data));
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
