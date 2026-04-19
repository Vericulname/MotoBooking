
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
                return context.TbDonDatXes.ToList();
            }
        }
        public TblDonDatXe GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbDonDatXes.Find(id);
            }
        }
        public TblDonDatXe Add(TblDonDatXe donDatXe)
        {
            using (var context = new MotoBookingContext())
            {
                context.Attach(donDatXe.FkIXeNavigation);
                context.Attach(donDatXe.FkIKhachhangNavigation);
               
                context.TbDonDatXes.Add(donDatXe);
                context.SaveChanges();
                return donDatXe;
            }
        }
        public TblDonDatXe Update(TblDonDatXe donDatXe)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbDonDatXes.Update(donDatXe);
                context.SaveChanges();
                return donDatXe;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var donDatXe = context.TbDonDatXes.Find(id);
                
                    context.TbDonDatXes.Remove(donDatXe);
                context.SaveChanges();
                
            }
        }
    }
}
