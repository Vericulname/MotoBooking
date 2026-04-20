using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblHoaDon")]
public partial class TblHoaDon
{
    [Key]
    [Column("PK_iHoaDon")]
    public int PkIHoaDon { get; set; }

    [Column("FK_iHopDong")]
    public int FkIHopDong { get; set; }

    [Column("dNgayLap", TypeName = "datetime")]
    public DateTime? DNgayLap { get; set; }

    [Column("FK_iLoaiHuHong")]
    public int? FkILoaiHuHong { get; set; }

    [Column("sPhuongThucThanhToan")]
    [StringLength(20)]
    public string SPhuongThucThanhToan { get; set; } = null!;

    [Column("sTrangThaiThanhToan")]
    [StringLength(20)]
    public string STrangThaiThanhToan { get; set; } = null!;

    [ForeignKey("FkIHopDong")]
    [InverseProperty("TblHoaDons")]
    public virtual TblHopDong FkIHopDongNavigation { get; set; } = null!;

    [ForeignKey("FkILoaiHuHong")]
    [InverseProperty("TblHoaDons")]
    public virtual TblLoaiHuHong? FkILoaiHuHongNavigation { get; set; }
}
