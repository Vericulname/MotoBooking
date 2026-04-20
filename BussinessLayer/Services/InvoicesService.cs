using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BussinessLayer.Services
{
    public class InvoicesService
    {
        private InvoiceRepos _Repos;

        private ContractsRepos _ContractRepos;

        private Mapper _modelmapper;
        private Mapper _requestmapper;

        public InvoicesService()
        {
            _Repos = new InvoiceRepos();
            _ContractRepos =  new ContractsRepos();

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
                throw new Exception("Không tìm thấy hoá đơn với id: " + id);
            }
            InvoiceModel model = _modelmapper.Map<TblHoaDon, InvoiceModel>(data);
            return model;
            
        }
  
        public InvoiceModel Create(InvoiceRequest request)
        {

            try
            {
                TblHoaDon data = _requestmapper.Map<InvoiceRequest, TblHoaDon>(request);
                if (request.FkILoaiHuHong == 0)
                {
                    data.FkILoaiHuHong = null;
                }
                return _modelmapper.Map<InvoiceModel>(_Repos.Add(data));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            
            
         
        }
        //đặt giá trị cho tblhoadon từ request
        private TblHoaDon UpdateValues(TblHoaDon data, InvoiceRequest request)
        {
            if (_ContractRepos.GetById( (int ) request.FkIHopDong) == null)
            {
                throw new Exception("không tìm thấy hợp đồng với id: " +request.FkIHopDong);
            }
            if (request.FkILoaiHuHong ==0)
            {
                request.FkILoaiHuHong = null;
            }

            data.FkILoaiHuHong = request.FkILoaiHuHong;
            data.FkIHopDong = request.FkIHopDong;
            data.SPhuongThucThanhToan = request.SPhuongThucThanhToan;
            data.STrangThaiThanhToan = request.STrangThaiThanhToan;
            return data;

        }
        public InvoiceModel Update(int id, InvoiceRequest request)
        {
            TblHoaDon data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("không tìm thấy hoá đơn với id"+ id);
            }
            try
            {
                data = UpdateValues(data, request);
                return _modelmapper.Map<TblHoaDon, InvoiceModel>(_Repos.Update(data));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
         
        }
    
        public void Delete(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy hoá đơn với id: " + id);
            }
            _Repos.Delete(id);
        }
    }
}
