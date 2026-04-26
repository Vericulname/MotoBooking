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
        private AccountsRepos _AccountsRepos;

        private Mapper _modelmapper;
        private Mapper _requestmapper;


        public EmployeesService()
        {
            _Repos = new EmployeesRepos();
            _AccountsRepos =  new AccountsRepos();
            _modelmapper = ModelMapper<TblNhanvien, EmployeesModel>.createMap();
            _requestmapper = ModelMapper<TblNhanvien, EmployeesRequest>.createMap();
            
        }
        public List<EmployeesModel> GetAll()
        {
            List<TblNhanvien> data = _Repos.GetAll();
            List<EmployeesModel> lst = _modelmapper.Map<List<TblNhanvien>, List<EmployeesModel>>(data);
            return lst;
        }
        public EmployeesModel GetById(int id)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
                throw new Exception("Không tìm thấy nhân viên với id: " + id);
            }
            EmployeesModel model = _modelmapper.Map<TblNhanvien, EmployeesModel>(data);
            return model;
            
        }
       
        public EmployeesModel Create(RegisterAccRequest request)
        {
            TblNhanvien data = new TblNhanvien();
            data.SHoTen = request.SHoTen;

            TblTaiKhoan account = new TblTaiKhoan();

            account.SSoDienThoai = request.SSoDienThoai;
            account.SVaiTro = request.SVaiTro!;
            account.SMatKhau = request.SMatKhau;

            _AccountsRepos.Add(account);

            var FKTaikhoan = _AccountsRepos.GetByName(request.SSoDienThoai);

            data.FkITaiKhoan = FKTaikhoan.PkITaiKhoan;
         



            return _modelmapper.Map<TblNhanvien, EmployeesModel>(_Repos.Add(data));
        }
        public EmployeesModel Update(int id,EmployeesRequest request)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {
            
                throw new Exception("Không tìm thấy nhân viên với id: " + id);

            }
            _requestmapper.Map<EmployeesRequest, TblNhanvien>(request, data);
            return _modelmapper.Map<TblNhanvien, EmployeesModel>(_Repos.Update(data));
        }

        public EmployeesModel UpdateRole(int id, string role)
        {
            var data = _Repos.GetById(id);
            if (data == null)
            {

                throw new Exception("Không tìm thấy nhân viên với id: " + id);

            }

            var account = _AccountsRepos.GetById( (int) data.FkITaiKhoan!);
            account.SVaiTro = role;
            _AccountsRepos.Update(account);

            return _modelmapper.Map<TblNhanvien, EmployeesModel>(_Repos.Update(data));
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
