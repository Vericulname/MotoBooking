using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class OrdersModel
    {
        public int PkIDonDat { get; set; }
        public int FkIKhachhang { get; set; }
        public int FkIXe { get; set; }
        public decimal FGiaTamTinh { get; set; }

        public decimal FTienCoc { get; set; }
        public bool BTrangThai { get; set; }

        public DateTime DThoiGianBatDau { get; set; }
        public DateTime DThoiGianKetThuc { get; set; }
        public DateTime? DNgayTao { get; set; }
        public DateTime? DNgayHuy { get; set; }
    }
}
