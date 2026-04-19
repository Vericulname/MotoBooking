using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;

namespace BussinessLayer.Services
{
    public class InvoicesService
    {
        private InvoiceRepos _Repos;
        private Mapper _modelmapper;
        private Mapper _requestmapper;

        public InvoicesService()
        {
            _Repos = new InvoiceRepos();
            _modelmapper = ModelMapper<TblHoaDon, InvoiceModel>.createMap();
            _requestmapper =  ModelMapper<InvoiceRequest,TblHoaDon>.createMap();
        }
        public List<InvoiceModel> GetAll()
        {
            List<TblHoaDon> data = _Repos.GetAll();
            List<InvoiceModel> lst = _modelmapper.Map<List<TblHoaDon>, List<InvoiceModel>>(data);
            return lst;
        }
        public InvoiceModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy khách hàng với id: " + id);
            }
            InvoiceModel model = _modelmapper.Map<TblHoaDon, InvoiceModel>(data);
            return model;
            
        }
  
        public InvoiceModel Create(InvoiceRequest request)
        {
            var data = _requestmapper.Map<TblHoaDon>(request);

            return _modelmapper.Map<InvoiceModel>(data);
            
        }
        public InvoiceModel Update(int id, InvoiceRequest request)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy khách hàng với id: " + id);

            }
            data = _modelmapper.Map<TblHoaDon>(request);

            return _modelmapper.Map<TblHoaDon, InvoiceModel>(_Repos.Update(data));
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
