
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class DamageTypeRepos
    {
        public List<TblLoaiHuHong> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblLoaiHuHongs.ToList();
            }
        }
        public TblLoaiHuHong GetById(int? id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblLoaiHuHongs.Find(id);
            }
        }
        public TblLoaiHuHong Add(TblLoaiHuHong khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblLoaiHuHongs.Add(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public TblLoaiHuHong Update(TblLoaiHuHong khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblLoaiHuHongs.Update(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var loaiHuHong = context.TblLoaiHuHongs.Find(id);
                
                    context.TblLoaiHuHongs.Remove(loaiHuHong);
                context.SaveChanges();
                
            }
        }
    }
}
