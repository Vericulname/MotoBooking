
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class TbHopDongRepos
    {
        public List<TbHopDong> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbHopDongs.ToList();
            }
        }
        public TbHopDong GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbHopDongs.Find(id);
            }
        }
        public TbHopDong Add(TbHopDong khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbHopDongs.Add(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public TbHopDong Update(TbHopDong khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbHopDongs.Update(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var hopDong = context.TbHopDongs.Find(id);
                
                    context.TbHopDongs.Remove(hopDong);
                context.SaveChanges();
                
            }
        }
    }
}
