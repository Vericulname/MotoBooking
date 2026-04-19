
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
                return context.TbXes.ToList();
            }
        }
        public TblXe GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbXes.Find(id);
            }
        }
        public TblXe Create(TblXe xe)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbXes.Add(xe);
                context.SaveChanges();
                return xe;
            }
        }
        public TblXe Update(TblXe xe)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbXes.Update(xe);
                context.SaveChanges();
                return xe;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var xe = context.TbXes.Find(id);
                
                    context.TbXes.Remove(xe);
                context.SaveChanges();
                
            }
        }
    }
}
