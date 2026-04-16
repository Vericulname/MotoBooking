
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
        public List<TbLoaiHuHong> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbLoaiHuHongs.ToList();
            }
        }
        public TbLoaiHuHong GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbLoaiHuHongs.Find(id);
            }
        }
        public TbLoaiHuHong Add(TbLoaiHuHong khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbLoaiHuHongs.Add(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public TbLoaiHuHong Update(TbLoaiHuHong khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbLoaiHuHongs.Update(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var loaiHuHong = context.TbLoaiHuHongs.Find(id);
                
                    context.TbLoaiHuHongs.Remove(loaiHuHong);
                context.SaveChanges();
                
            }
        }
    }
}
