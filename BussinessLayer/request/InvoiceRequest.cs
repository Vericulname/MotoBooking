using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.request
{
    public class InvoiceRequest
    {
        public int FkIHopDong { get; set; }
        public int? FkILoaiHuHong { get; set; } = null;
        public string SPhuongThucThanhToan { get; set; }
        public string STrangThaiThanhToan { get; set; }
        //public DateTime? DNgayLap { get; set; }
    }
}
