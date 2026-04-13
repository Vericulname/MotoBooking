using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TbHoaDon
{
    public int PkIHoaDon { get; set; }

    public int? FkIHopDong { get; set; }

    public DateTime? DNgayLap { get; set; }

    public decimal? FTongTien { get; set; }

    public string? SPhuongThucThanhToan { get; set; }

    public string? STrangThaiThanhToan { get; set; }

    public virtual TbHopDong? FkIHopDongNavigation { get; set; }
}
