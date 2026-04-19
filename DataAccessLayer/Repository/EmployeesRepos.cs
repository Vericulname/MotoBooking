
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
                return context.TbNhanviens.ToList();
            }
        }
        public TblNhanvien GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbNhanviens.Find(id);
            }
        }
        public TblNhanvien Add(TblNhanvien nhanvien)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbNhanviens.Add(nhanvien);
                context.SaveChanges();
                return nhanvien;
            }
        }
        public TblNhanvien Update(TblNhanvien nhanvien)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbNhanviens.Update(nhanvien);
                context.SaveChanges();
                return nhanvien;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var nhanvien = context.TbNhanviens.Find(id);
                
                context.TbNhanviens.Remove(nhanvien);
                context.SaveChanges();
                
            }
        }
    }
}
