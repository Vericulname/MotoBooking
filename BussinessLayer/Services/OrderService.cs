using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BussinessLayer.Services
{
    public class OrderService
    {
        private OrdersRepos _OrdersRepos;
        private CustomersRepos _CustomersRepos;
        private VehiclesRepos _VehiclesRepos;

        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public OrderService()
        {
            _OrdersRepos = new OrdersRepos();
            _CustomersRepos = new CustomersRepos();
            _VehiclesRepos = new VehiclesRepos();

            _modelmapper = ModelMapper<TblDonDatXe, OrdersModel>.createMap();
            _requestmapper = ModelMapper<TblDonDatXe, OrdersRequest>.createMap();
        }
        public List<OrdersModel> GetAll()
        {
            List<TblDonDatXe> data = _OrdersRepos.GetAll();
            List<OrdersModel> lst = _modelmapper.Map<List<TblDonDatXe>, List<OrdersModel>>(data);
            return lst;
        }
        public OrdersModel GetById(int id)
        {
            var data = _OrdersRepos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy đơn đặt xe với id: " + id);
            }
            OrdersModel model = _modelmapper.Map<TblDonDatXe, OrdersModel>(data);
            return model;
            
        }
        public OrdersModel Create(OrdersRequest request)
        {
            try
            {

                TblDonDatXe data = _requestmapper.Map<TblDonDatXe>(request);
                data = setFkNav(data , request);


                return _modelmapper.Map<TblDonDatXe, OrdersModel>(_OrdersRepos.Add(data));
            }

            catch (Exception ex) {
                throw new Exception("không thể tạo đơn đặt xe:" + ex.Message);
            }
           
            
            
        }
        //đặt khoá ngoại
        private TblDonDatXe setFkNav(TblDonDatXe data, OrdersRequest request)
        {
            var customer = _CustomersRepos.GetById((int) request.FkIKhachhang);
            var vehicle = _VehiclesRepos.GetById((int) request.FkIXe);

            if (customer == null)
            {
                throw new Exception("phải có id khách hàng");
            }
            if (vehicle == null)
            {
                throw new Exception("phải có id xe");
            }

            _requestmapper.Map<OrdersRequest, TblDonDatXe>(request, data);

            data.FkIXe = request.FkIXe;
            data.FkIKhachhang = request.FkIKhachhang;
            return data;
        }
        public OrdersModel Update(int id,OrdersRequest request)
        {
            var data = _OrdersRepos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy đơn đặt xe với id: " + id);

            }

            try{
               
                setFkNav(data, request);
                return _modelmapper.Map<TblDonDatXe, OrdersModel>(_OrdersRepos.Update(data));
            }

            catch (Exception ex)
            {
                throw new Exception("không thể tạo đơn đặt xe:" + ex.Message);
            }
    
        }
        public void Delete(int id)
        {
            var data = _OrdersRepos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy đơn đặt xe với id: " + id);
            }
            _OrdersRepos.Delete(id);
        }
    }
}
