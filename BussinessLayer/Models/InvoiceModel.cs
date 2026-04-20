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
    public class InvoiceModel
    {
        public int PkIHoaDon { get; set; }
        public int FkIHopDong { get; set; }
        public int? FkILoaiHuHong { get; set; }
        public string SPhuongThucThanhToan { get; set; }
        public string STrangThaiThanhToan { get; set; }
        public DateTime? DNgayLap { get; set; }


    }
}
