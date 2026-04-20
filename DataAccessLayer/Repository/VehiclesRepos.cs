
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class VehiclesRepos
    {
        public List<TblXe> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblXes.ToList();
            }
        }
        public TblXe GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblXes.Find(id);
            }
        }
        public TblXe Create(TblXe xe)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblXes.Add(xe);
                context.SaveChanges();
                return xe;
            }
        }
        public TblXe Update(TblXe xe)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblXes.Update(xe);
                context.SaveChanges();
                return xe;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var xe = context.TblXes.Find(id);
                
                    context.TblXes.Remove(xe);
                context.SaveChanges();
                
            }
        }
    }
}
