using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;

namespace BussinessLayer.Services
{
    public class TbKhachHangService
    {
        private TbKhachHangRepos _Repos;
        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public TbKhachHangService()
        {
            _Repos = new TbKhachHangRepos();

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
            });
            MapperConfiguration _modelconfig = new(static cfg => cfg.CreateMap<TbKhachhang, TbKhachHangModel>().ReverseMap(), loggerFactory);
            MapperConfiguration _requestconfig = new(static cfg => cfg.CreateMap<TbKhachhang, KhachHangRequest>().ReverseMap(), loggerFactory);

            _modelmapper = new Mapper(_modelconfig);
            _requestmapper = new Mapper(_requestconfig);
        }
        public List<TbKhachHangModel> GetAll()
        {
            List<TbKhachhang> data = _Repos.GetAll();
            List<TbKhachHangModel> lst = _modelmapper.Map<List<TbKhachhang>, List<TbKhachHangModel>>(data);
            return lst;
        }
        public TbKhachHangModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với id: " + id);
            }
            TbKhachHangModel model = _modelmapper.Map<TbKhachhang, TbKhachHangModel>(data);
            return model;
            
        }
        public TbKhachHangModel Create(KhachHangRequest request)
        {
            TbKhachhang data = _requestmapper.Map<KhachHangRequest, TbKhachhang>(request);
            
            return _modelmapper.Map<TbKhachhang, TbKhachHangModel>(_Repos.Add(data));
        }
        public TbKhachHangModel Update(int id,KhachHangRequest request)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy khách hàng với id: " + id);

            }
            _requestmapper.Map<KhachHangRequest, TbKhachhang>(request, data);
            return _modelmapper.Map<TbKhachhang, TbKhachHangModel>(_Repos.Update(data));
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
