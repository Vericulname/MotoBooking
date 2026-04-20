
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
                return context.TblHoaDons.ToList();
            }
        }
        public TblHoaDon GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblHoaDons.Find(id);
            }
        }
        public TblHoaDon Add(TblHoaDon hoaDon)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblHoaDons.Add(hoaDon);
                context.SaveChanges();
                return hoaDon;
            }
        }
        public TblHoaDon Update(TblHoaDon hoaDon)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblHoaDons.Update(hoaDon);
                context.SaveChanges();
                return hoaDon;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var hoaDon = context.TblHoaDons.Find(id);
                
                    context.TblHoaDons.Remove(hoaDon);
                context.SaveChanges();
                
            }
        }
    }
}
