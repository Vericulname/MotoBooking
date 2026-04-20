using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblHopDong")]
public partial class TblHopDong
{
    [Key]
    [Column("PK_iHopDong")]
    public int PkIHopDong { get; set; }

    [Column("FK_iDonDat")]
    public int? FkIDonDat { get; set; }

    [Column("FK_iKhachhang")]
    public int FkIKhachhang { get; set; }

    [Column("FK_iNhanvien")]
    public int FkINhanvien { get; set; }

    [Column("FK_iXe")]
    public int FkIXe { get; set; }

    [Column("dGiaoThucTe", TypeName = "datetime")]
    public DateTime? DGiaoThucTe { get; set; }

    [Column("dTraDuKien", TypeName = "datetime")]
    public DateTime DTraDuKien { get; set; }

    [Column("dTraThucTe", TypeName = "datetime")]
    public DateTime DTraThucTe { get; set; }

    [Column("fTienCocDaNhan", TypeName = "decimal(10, 2)")]
    public decimal FTienCocDaNhan { get; set; }

    [ForeignKey("FkIDonDat")]
    [InverseProperty("TblHopDongs")]
    public virtual TblDonDatXe? FkIDonDatNavigation { get; set; }

    [ForeignKey("FkIKhachhang")]
    [InverseProperty("TblHopDongs")]
    public virtual TblKhachhang FkIKhachhangNavigation { get; set; } = null!;

    [ForeignKey("FkINhanvien")]
    [InverseProperty("TblHopDongs")]
    public virtual TblNhanvien FkINhanvienNavigation { get; set; } = null!;

    [ForeignKey("FkIXe")]
    [InverseProperty("TblHopDongs")]
    public virtual TblXe FkIXeNavigation { get; set; } = null!;

    [InverseProperty("FkIHopDongNavigation")]
    public virtual ICollection<TblHoaDon> TblHoaDons { get; set; } = new List<TblHoaDon>();
}
