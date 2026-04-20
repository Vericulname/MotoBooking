using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.request
{
    public class OrdersRequest
    {
        public int FkIKhachhang { get; set; }
        public int FkIXe { get; set; }
        public decimal? FGiaTamTinh { get; set; }
        public decimal FTienCoc { get; set; }

        public bool BTrangThai { get; set; }
        public DateTime DThoiGianBatDau { get; set; }

        public DateTime DThoiGianKetThuc { get; set; }
        public DateTime? DNgayHuy { get; set; }

    }
}
