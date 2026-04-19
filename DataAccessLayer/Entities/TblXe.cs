using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblXe")]
[Index("SBienSo", Name = "UQ__tbXe__EDF66DCF673901C5", IsUnique = true)]
public partial class TblXe
{
    [Key]
    [Column("PK_iXe")]
    public int PkIXe { get; set; }

    [Column("sBienSo")]
    [StringLength(20)]
    [Unicode(false)]
    public string SBienSo { get; set; } = null!;

    [Column("sThuongHieu")]
    [StringLength(50)]
    public string? SThuongHieu { get; set; }

    [Column("sLoaiXe")]
    [StringLength(50)]
    public string? SLoaiXe { get; set; }

    [Column("iSoGhe")]
    public int? ISoGhe { get; set; }

    [Column("fGiaNgay", TypeName = "decimal(10, 2)")]
    public decimal FGiaNgay { get; set; }

    [Column("fGiaGio", TypeName = "decimal(10, 2)")]
    public decimal? FGiaGio { get; set; }

    [Column("sTrangThai")]
    [StringLength(20)]
    public string? STrangThai { get; set; }

    [Column("sAnhURL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SAnhUrl { get; set; }

    [Column("sMoTa", TypeName = "ntext")]
    public string? SMoTa { get; set; }

    [InverseProperty("FkIXeNavigation")]
    public virtual ICollection<TblDonDatXe> TbDonDatXes { get; set; } = new List<TblDonDatXe>();

    [InverseProperty("FkIXeNavigation")]
    public virtual ICollection<TblHopDong> TbHopDongs { get; set; } = new List<TblHopDong>();
}
