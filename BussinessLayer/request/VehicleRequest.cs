using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.request
{
    public class VehicleRequest
    {
        public string SBienSo { get; set; } = null!;
        public string? SThuongHieu { get; set; }

        public string? SLoaiXe { get; set; }


        public int? ISoGhe { get; set; }


        public decimal FGiaNgay { get; set; }


        public decimal? FGiaGio { get; set; }

        public string? STrangThai { get; set; }
        public string? SAnhUrl { get; set; }


        public string? SMoTa { get; set; }
    }
}
