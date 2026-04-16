
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
        public List<TbKhachhang> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbKhachhangs.ToList();
            }
        }
        public TbKhachhang GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbKhachhangs.Find(id);
            }
        }
        public TbKhachhang GetByName(String name)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbKhachhangs.FirstOrDefault(k => k.SHoTen == name);
            }
        }
        public TbKhachhang Add(TbKhachhang khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbKhachhangs.Add(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public TbKhachhang Update(TbKhachhang khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbKhachhangs.Update(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var khachhang = context.TbKhachhangs.Find(id);
                
                    context.TbKhachhangs.Remove(khachhang);
                context.SaveChanges();
                
            }
        }
    }
}
