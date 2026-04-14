using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tbHoaDon")]
public partial class TbHoaDon
{
    [Key]
    [Column("PK_iHoaDon")]
    public int PkIHoaDon { get; set; }

    [Column("FK_iHopDong")]
    public int? FkIHopDong { get; set; }

    [Column("dNgayLap", TypeName = "datetime")]
    public DateTime? DNgayLap { get; set; }

    [Column("fTongTien", TypeName = "decimal(10, 2)")]
    public decimal? FTongTien { get; set; }

    [Column("sPhuongThucThanhToan")]
    [StringLength(20)]
    public string? SPhuongThucThanhToan { get; set; }

    [Column("sTrangThaiThanhToan")]
    [StringLength(20)]
    public string? STrangThaiThanhToan { get; set; }

    [ForeignKey("FkIHopDong")]
    [InverseProperty("TbHoaDons")]
    public virtual TbHopDong? FkIHopDongNavigation { get; set; }
}
