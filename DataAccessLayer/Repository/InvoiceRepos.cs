
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class InvoiceRepos
    {
        public List<TblHoaDon> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbHoaDons.ToList();
            }
        }
        public TblHoaDon GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbHoaDons.Find(id);
            }
        }
        public TblHoaDon Add(TblHoaDon hoaDon)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbHoaDons.Add(hoaDon);
                context.SaveChanges();
                return hoaDon;
            }
        }
        public TblHoaDon Update(TblHoaDon hoaDon)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbHoaDons.Update(hoaDon);
                context.SaveChanges();
                return hoaDon;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var hoaDon = context.TbHoaDons.Find(id);
                
                    context.TbHoaDons.Remove(hoaDon);
                context.SaveChanges();
                
            }
        }
    }
}
