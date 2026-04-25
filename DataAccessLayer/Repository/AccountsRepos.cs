
using DataAccessLayer.Context;
using DataAccessLayer.Entities;



namespace DataAccessLayer.Repository
{
    public class AccountsRepos
    {
        public List<TblTaiKhoan> GetAll()
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblTaiKhoans.ToList();
            }
        }
        public TblTaiKhoan GetById(int id)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblTaiKhoans.Find(id);
            }
        }
        public TblTaiKhoan GetByName(string name)
        {
            using (var context = new MotoBookingContext())
            {
                return context.TblTaiKhoans.FirstOrDefault(k => k.SSoDienThoai == name);
            }
        }
        public TblTaiKhoan GetByNameAndPass(string name, string pass)
        {
            using (var context = new MotoBookingContext())
            {
                TblTaiKhoan data = context.TblTaiKhoans.
                    FirstOrDefault(k => k.SSoDienThoai == name && k.SMatKhau == pass);

                return data;
            }
        }
        public TblTaiKhoan Add(TblTaiKhoan taikhoan)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblTaiKhoans.Add(taikhoan);
                context.SaveChanges();
                return taikhoan;
            }
        }
        public TblTaiKhoan Update(TblTaiKhoan taikhoan)
        {
            using (var context = new MotoBookingContext())
            {
                context.TblTaiKhoans.Update(taikhoan);
                context.SaveChanges();
                return taikhoan;
            }
        }
        public void Delete(int id)
        {
            using (var context = new MotoBookingContext())
            {
                var taikhoan = context.TblTaiKhoans.Find(id);
                
                    context.TblTaiKhoans.Remove(taikhoan);
                context.SaveChanges();
                
            }
        }
    }
}
