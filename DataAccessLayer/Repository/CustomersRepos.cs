
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CustomersRepos
    {
        public List<TblKhachhang> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblKhachhangs.ToList();
            }
        }
        public TblKhachhang GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblKhachhangs.Find(id);
            }
        }
        public TblKhachhang GetByName(String name)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblKhachhangs.FirstOrDefault(k => k.SHoTen == name);
            }
        }
        public TblKhachhang Add(TblKhachhang khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblKhachhangs.Add(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public TblKhachhang Update(TblKhachhang khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblKhachhangs.Update(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var khachhang = context.TblKhachhangs.Find(id);
                
                    context.TblKhachhangs.Remove(khachhang);
                context.SaveChanges();
                
            }
        }
    }
}
