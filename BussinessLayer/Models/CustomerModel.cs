using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public partial class CustomerModel
    {
        public int PkIKhachhang { get; set; }

        public string SHoTen { get; set; } = null!;
        public virtual TblTaiKhoan? FkITaiKhoanNavigation { get; set; }

        public string? SCccd { get; set; }

        public string? SEmail { get; set; }

        public string? SDiaChi { get; set; }

        public DateTime? DNgayTao { get; set; }
    }
}
