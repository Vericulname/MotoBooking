using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TbDonDatXe
{
    public int PkIDonDat { get; set; }

    public int? FkIKhachhang { get; set; }

    public int? FkIXe { get; set; }

    public DateTime DThoiGianBatDau { get; set; }

    public DateTime DThoiGianKetThuc { get; set; }

    public decimal? FGiaTamTinh { get; set; }

    public decimal? FTienCoc { get; set; }

    public string? STrangThai { get; set; }

    public DateTime? DNgayTao { get; set; }

    public DateTime? DNgayHuy { get; set; }

    public virtual TbKhachhang? FkIKhachhangNavigation { get; set; }

    public virtual TbXe? FkIXeNavigation { get; set; }

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
