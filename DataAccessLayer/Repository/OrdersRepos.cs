
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
        public List<TbDonDatXe> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbDonDatXes.ToList();
            }
        }
        public TbDonDatXe GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbDonDatXes.Find(id);
            }
        }
        public TbDonDatXe Add(TbDonDatXe donDatXe)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbDonDatXes.Add(donDatXe);
                context.SaveChanges();
                return donDatXe;
            }
        }
        public TbDonDatXe Update(TbDonDatXe donDatXe)
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
