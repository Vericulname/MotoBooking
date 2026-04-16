using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class VehiclesModel
    {
        public int PkIXe { get; set; }
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
