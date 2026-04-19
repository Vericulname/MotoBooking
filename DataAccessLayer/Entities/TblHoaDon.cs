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
    public int? FkIHopDong { get; set; }

    [Column("dNgayLap", TypeName = "datetime")]
    public DateTime? DNgayLap { get; set; }

    [Column("sPhuongThucThanhToan")]
    [StringLength(20)]
    public string? SPhuongThucThanhToan { get; set; }

    [Column("sTrangThaiThanhToan")]
    [StringLength(20)]
    public string? STrangThaiThanhToan { get; set; }

    [ForeignKey("FkIHopDong")]
    [InverseProperty("TbHoaDons")]
    public virtual TblHopDong? FkIHopDongNavigation { get; set; }
}
