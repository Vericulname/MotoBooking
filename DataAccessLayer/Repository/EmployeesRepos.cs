
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmployeesRepos
    {
        public List<TblNhanvien> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblNhanviens.ToList();
            }
        }
        public TblNhanvien GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblNhanviens.Find(id);
            }
        }
        public TblNhanvien Add(TblNhanvien nhanvien)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblNhanviens.Add(nhanvien);
                context.SaveChanges();
                return nhanvien;
            }
        }
        public TblNhanvien Update(TblNhanvien nhanvien)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblNhanviens.Update(nhanvien);
                context.SaveChanges();
                return nhanvien;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var nhanvien = context.TblNhanviens.Find(id);
                
                context.TblNhanviens.Remove(nhanvien);
                context.SaveChanges();
                
            }
        }

        public TblNhanvien GetByFkAccount(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblNhanviens.FirstOrDefault(k => k.FkITaiKhoan == id);
            }
        }
    }
}
