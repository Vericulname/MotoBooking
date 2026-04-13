using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TbHopDong
{
    public int PkIHopDong { get; set; }

    public int? FkIDonDat { get; set; }

    public int? FkIKhachhang { get; set; }

    public int? FkINhanvien { get; set; }

    public int? FkILoaiHuHong { get; set; }

    public int? FkIXe { get; set; }

    public DateTime? DGiaoThucTe { get; set; }

    public DateTime? DTraDuKien { get; set; }

    public DateTime? DTraThucTe { get; set; }

    public decimal? FTienCocDaNhan { get; set; }

    public decimal? FTienThueThucTe { get; set; }

    public decimal? FPhatTraMuon { get; set; }

    public decimal? FPhatHuHong { get; set; }

    public decimal? FTongTien { get; set; }

    public decimal? FTienHoanLai { get; set; }

    public string? STrangThai { get; set; }

    public virtual TbDonDatXe? FkIDonDatNavigation { get; set; }

    public virtual TbKhachhang? FkIKhachhangNavigation { get; set; }

    public virtual TbLoaiHuHong? FkILoaiHuHongNavigation { get; set; }

    public virtual TbNhanvien? FkINhanvienNavigation { get; set; }

    public virtual TbXe? FkIXeNavigation { get; set; }

    public virtual ICollection<TbHoaDon> TbHoaDons { get; set; } = new List<TbHoaDon>();
}
