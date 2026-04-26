using AutoMapper;
using BussinessLayer.Models;
using BussinessLayer.request;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class AuthenticationService
    {
        private readonly AccountsRepos _Repos;
        private readonly Mapper _mapper;
        private readonly CustomersRepos _customersRepos;
        private readonly EmployeesRepos _employeesRepos;
        public AuthenticationService() {
            _Repos = new AccountsRepos();
            _customersRepos = new CustomersRepos();
            _employeesRepos = new EmployeesRepos();

            _mapper = ModelMapper<TblTaiKhoan, RegisterAccRequest>.createMap();
        }

        public TblTaiKhoan login(LoginAccRequest request)
        {
            var user = _Repos.GetByNameAndPass(request.SDT, request.password);
            if (user == null)
            {
                throw new Exception("tên tài khoản hoặc mật khẩu ko đúng");
            }
            return user;
            
        }
        public void register(RegisterAccRequest request)
        {
            var user = _Repos.GetByName(request.SSoDienThoai);
            if (user != null)
            {
                throw new Exception("số điện thoại đã tồn tại");
            }
            
            user = _mapper.Map<TblTaiKhoan>(request);
            user.SVaiTro = user.SVaiTro!.ToLower();

            _Repos.Add(user);

            if (String.Equals("cusomter", user.SVaiTro!.ToLower()))
            {
                TblKhachhang customer = new TblKhachhang();
                customer.SHoTen = request.SHoTen;


                _customersRepos.Add(customer);
            }
            else
            {
                TblNhanvien employee = new TblNhanvien();
                employee.SHoTen = request.SHoTen;

                _employeesRepos.Add(employee);
            }
        }
        public void registerCustomer(RegisterCustomerRequest request)
        {
            var user = _Repos.GetByName(request.SSoDienThoai);
            if (user != null)
            {
                throw new Exception("số điện thoại đã tồn tại");
            }

            user = _mapper.Map<TblTaiKhoan>(request);
            user.SVaiTro = user.SVaiTro!.ToLower();

            _Repos.Add(user);

            
            TblKhachhang customer = new TblKhachhang();
            customer.SHoTen = request.SHoTen;


            _customersRepos.Add(customer);
            

        }

        public void UpdateRole(int id, string role)
        {
            var user = _Repos.GetById(id);
            if (user == null)
            {
                throw new Exception("tài khoản không tồn tại");
            }
            user.SVaiTro = role;
            _Repos.Update(user);

        }
        public void Delete(int id)
        {
            var user = _Repos.GetById(id);
            if (user == null)
            {
                throw new Exception("tài khoản không tồn tại");
            }
            
            _Repos.Delete(id);

        }
    }
}
