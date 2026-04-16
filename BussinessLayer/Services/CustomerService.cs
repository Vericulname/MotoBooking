using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;

namespace BussinessLayer.Services
{
    public class CustomerService
    {
        private CustomersRepos _Repos;
        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public CustomerService()
        {
            _Repos = new CustomersRepos();
            _modelmapper = ModelMapper<TbKhachhang, CustomerModel>.createMap();
            _requestmapper = ModelMapper<TbKhachhang, CustomerRequest>.createMap();
        }
        public List<CustomerModel> GetAll()
        {
            List<TbKhachhang> data = _Repos.GetAll();
            List<CustomerModel> lst = _modelmapper.Map<List<TbKhachhang>, List<CustomerModel>>(data);
            return lst;
        }
        public CustomerModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với id: " + id);
            }
            CustomerModel model = _modelmapper.Map<TbKhachhang, CustomerModel>(data);
            return model;
            
        }
        public CustomerModel GetByName(string name)
        {
            var data = _Repos.GetByName(name);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với tên: " + name);
            }
            CustomerModel model = _modelmapper.Map<TbKhachhang, CustomerModel>(data);
            return model;

        }
        public CustomerModel Create(CustomerRequest request)
        {
            TbKhachhang data = _requestmapper.Map<CustomerRequest, TbKhachhang>(request);
            
            return _modelmapper.Map<TbKhachhang, CustomerModel>(_Repos.Add(data));
        }
        public CustomerModel Update(int id,CustomerRequest request)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy khách hàng với id: " + id);

            }
            _requestmapper.Map<CustomerRequest, TbKhachhang>(request, data);
            return _modelmapper.Map<TbKhachhang, CustomerModel>(_Repos.Update(data));
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
