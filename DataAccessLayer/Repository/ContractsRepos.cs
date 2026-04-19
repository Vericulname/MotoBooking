
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
        public TblHopDong Add(TblHopDong hopDong)
        {
            using (var context = new MotoBookingContext())
            {
                //context.Attach(hopDong.FkIDonDatNavigation);
                //context.Attach(hopDong.FkILoaiHuHongNavigation);

                //context.Attach(hopDong.FkIKhachhangNavigation);
                //context.Attach(hopDong.FkINhanvienNavigation);
                //context.Attach(hopDong.FkIXeNavigation);

                context.TbHopDongs.Add(hopDong);
                context.SaveChanges();
                return hopDong;
            }
        }
        public TblHopDong Update(TblHopDong hopDong)
        {
            using (var context = new MotoBookingContext())
            {
                //context.Attach(hopDong.FkIKhachhangNavigation);
                //context.Attach(hopDong.FkIDonDatNavigation);
                //context.Attach(hopDong.FkILoaiHuHongNavigation);
                //context.Attach(hopDong.FkINhanvienNavigation);
                //context.Attach(hopDong.FkIXeNavigation);
                

                context.TbHopDongs.Update(hopDong);
                context.SaveChanges();
                return hopDong;
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
