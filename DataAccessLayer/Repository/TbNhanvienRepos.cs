
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class TbNhanvienRepos
    {
        public List<TbNhanvien> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbNhanviens.ToList();
            }
        }
        public TbNhanvien GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TbNhanviens.Find(id);
            }
        }
        public TbNhanvien Add(TbNhanvien nhanvien)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbNhanviens.Add(nhanvien);
                context.SaveChanges();
                return nhanvien;
            }
        }
        public TbNhanvien Update(TbNhanvien nhanvien)
        {
            using (var context = new MotoBookingContext())
            {
                context.TbNhanviens.Update(nhanvien);
                context.SaveChanges();
                return nhanvien;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var nhanvien = context.TbNhanviens.Find(id);
                
                    context.TbNhanviens.Remove(nhanvien);
                context.SaveChanges();
                
            }
        }
    }
}
