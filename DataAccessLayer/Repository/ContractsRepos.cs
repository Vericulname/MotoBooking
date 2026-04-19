
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ContractsRepos
    {
        public List<TblHopDong> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbHopDongs.ToList();
            }
        }
        public TblHopDong GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbHopDongs.Find(id);
            }
        }
        public TblHopDong Add(TblHopDong khachhang)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbHopDongs.Add(khachhang);
                context.SaveChanges();
                return khachhang;
            }
        }
        public TblHopDong Update(TblHopDong khachhang)
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
