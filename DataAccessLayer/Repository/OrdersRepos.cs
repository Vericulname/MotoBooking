
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class OrdersRepos
    {
        public List<TblDonDatXe> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblDonDatXes.ToList();
            }
        }
        public TblDonDatXe GetById(int? id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblDonDatXes.Find(id);
            }
        }
        public TblDonDatXe Add(TblDonDatXe donDatXe)
        {
            using (var context = new MotoBookingContext())
            {
                //context.Attach(donDatXe.FkIXeNavigation);
                //context.Attach(donDatXe.FkIKhachhangNavigation);

                context.TblDonDatXes.Add(donDatXe);
                context.SaveChanges();
                return donDatXe;
            }
        }
        public TblDonDatXe Update(TblDonDatXe donDatXe)
        {
            using (var context = new MotoBookingContext())
            {
                //context.Attach(donDatXe.FkIXeNavigation);
                //context.Attach(donDatXe.FkIKhachhangNavigation);

                context.TblDonDatXes.Update(donDatXe);
                context.SaveChanges();
                return donDatXe;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var donDatXe = context.TblDonDatXes.Find(id);
                
                    context.TblDonDatXes.Remove(donDatXe);
                context.SaveChanges();
                
            }
        }
    }
}
