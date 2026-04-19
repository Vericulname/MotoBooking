using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.request
{
    public class ContractsRequest
    {
        public int? FkIDonDat { get; set; }
        public int? FkIKhachhang { get; set; }
        public int? FkINhanvien { get; set; }
        public int? FkIXe { get; set; }
        public int? FkILoaiHuHong { get; set; }
        public DateTime? DGiaoThucTe { get; set; }
        public DateTime? DTraDuKien { get; set; }
        public DateTime? DTraThucTe { get; set; }
        public decimal? FTienCocDaNhan { get; set; }
        public decimal? FTienThueThucTe { get; set; }
        public string? STrangThai { get; set; }
    }
}
