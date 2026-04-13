using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TbXe
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

    public virtual ICollection<TbDonDatXe> TbDonDatXes { get; set; } = new List<TbDonDatXe>();

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
