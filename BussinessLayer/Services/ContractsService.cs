using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace BussinessLayer.Services
{
    public class ContractsService
    {
        private ContractsRepos _ContractRepos;

        private OrdersRepos _OrdersRepos;
        private EmployeesRepos _EmployeesRepos;
        private DamageTypeRepos _DamageTypeRepos;
        private CustomersRepos _CustomerRepos;
        private VehiclesRepos _VehiclesRepos;

        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public ContractsService()
        {
            _ContractRepos = new ContractsRepos();

            _OrdersRepos = new OrdersRepos();
            _EmployeesRepos = new EmployeesRepos();
            _CustomerRepos = new CustomersRepos();
            _VehiclesRepos = new VehiclesRepos();
            _DamageTypeRepos = new DamageTypeRepos();

            _modelmapper = ModelMapper<TblHopDong, ContractsModel>.createMap();
            _requestmapper = ModelMapper<TblHopDong, ContractsRequest>.createMap();
        }
        public List<ContractsModel> GetAll()
        {
            List<TblHopDong> data = _ContractRepos.GetAll();
            List<ContractsModel> lst = _modelmapper.Map<List<TblHopDong>, List<ContractsModel>>(data);
            return lst;
        }
        public ContractsModel GetById(int id)
        {
            var data = _ContractRepos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy hợp đồng với id: " + id);
            }
            ContractsModel model = _modelmapper.Map<TblHopDong, ContractsModel>(data);
            return model;
            
        }
     
        public ContractsModel Create(ContractsRequest request)
        {

            try
            {

                TblHopDong data = _requestmapper.Map<ContractsRequest, TblHopDong>(request);

                data = setFkNav(data, request);


                return _modelmapper.Map<TblHopDong, ContractsModel>(_ContractRepos.Add(data));
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //đặt khoá ngoại
        private TblHopDong setFkNav(TblHopDong data,ContractsRequest request)
        {

            TblKhachhang customer = _CustomerRepos.GetById((int)request.FkIKhachhang);
            TblNhanvien employee = _EmployeesRepos.GetById((int)request.FkINhanvien);
            TblXe vehicle = _VehiclesRepos.GetById( (int)request.FkIXe);
            //TblDonDatXe order = new TblDonDatXe();
            //order.DThoiGianBatDau = DateTime.MaxValue;
            //order.DThoiGianKetThuc = DateTime.MaxValue;

            //TblLoaiHuHong damagetype = new TblLoaiHuHong();
            //damagetype.FPhiPhat = 0.0M;
            //damagetype.STenHuHong = "";

            if (_OrdersRepos.GetById(request.FkIDonDat) != null)
            {
                //order = _OrdersRepos.GetById((int)request.FkIDonDat);
                data.FkIDonDat = request.FkIDonDat;
            }
            
            if (_DamageTypeRepos.GetById(request.FkILoaiHuHong) != null)
            {
                data.FkILoaiHuHong = request.FkILoaiHuHong;
                //damagetype = _DamageTypeRepos.GetById((int)request.FkILoaiHuHong);
            }
          

            if (employee == null)
            {
                throw new Exception("phải có nhân viên");
            }
            if (customer == null)
            {
                throw new Exception("phái có khách hàng");
            }
            if (vehicle == null)
            {
                throw new Exception("phải có xe");
            }


            //data.FkIDonDatNavigation = order;
            //data.FkILoaiHuHongNavigation = damagetype;

            //data.FkINhanvienNavigation = employee;
            //data.FkIKhachhangNavigation = customer;
            //data.FkIXeNavigation = vehicle;

       
            data.FkIKhachhang = request.FkIKhachhang;
            data.FkINhanvien = request.FkINhanvien;
            data.FkIXe = request.FkIXe;
            
            return data;
        }
        public ContractsModel Update(int id,ContractsRequest request)
        {
            var data = _ContractRepos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy hợp đồng với id: " + id);

            }
            _requestmapper.Map<ContractsRequest, TblHopDong>(request, data);

            try
            {
                data = setFkNav(data, request);
                return _modelmapper.Map<TblHopDong, ContractsModel>(_ContractRepos.Update(data));
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
        public void Delete(int id)
        {
            var data = _ContractRepos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy hợp đồng với id: " + id);
            }
            _ContractRepos.Delete(id);
        }
    }
}
