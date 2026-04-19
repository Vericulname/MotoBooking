using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata.Ecma335;

namespace BussinessLayer.Services
{
    public class ContractsService
    {
        private ContractsRepos _ContractRepos;

        private OrdersRepos _OrdersRepos;
        private EmployeesRepos _EmployeesRepos;
        private DamageTypeRepos _DamageTypeRepos;

        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public ContractsService()
        {
            _ContractRepos = new ContractsRepos();

            _OrdersRepos = new OrdersRepos();
            _EmployeesRepos = new EmployeesRepos();

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

        
        private TblHopDong setFkNav(TblHopDong data,ContractsRequest request)
        {
            TblDonDatXe order = _OrdersRepos.GetById((int)request.FkIDonDat);
            TblNhanvien employee = _EmployeesRepos.GetById((int)request.FkINhanvien);
            TblLoaiHuHong damagetype = _DamageTypeRepos.GetById((int)request.FkILoaiHuHong);

            if (order == null)
            {
                throw new Exception("phải có đơn đặt xe");
            }
            if (employee == null)
            {
                throw new Exception("phải có nhân viên");
            }

            data.FkIDonDatNavigation = order;
            data.FkINhanvienNavigation = employee;
            data.FkILoaiHuHongNavigation = damagetype;

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

            data = setFkNav(data,request);
            return _modelmapper.Map<TblHopDong, ContractsModel>(_ContractRepos.Update(data));
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
