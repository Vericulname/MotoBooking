using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tbDonDatXe")]
public partial class TbDonDatXe
{
    [Key]
    [Column("PK_iDonDat")]
    public int PkIDonDat { get; set; }

    [Column("FK_iKhachhang")]
    public int? FkIKhachhang { get; set; }

    [Column("FK_iXe")]
    public int? FkIXe { get; set; }

    [Column("dThoiGianBatDau", TypeName = "datetime")]
    public DateTime DThoiGianBatDau { get; set; }

    [Column("dThoiGianKetThuc", TypeName = "datetime")]
    public DateTime DThoiGianKetThuc { get; set; }

    [Column("fGiaTamTinh", TypeName = "decimal(10, 2)")]
    public decimal? FGiaTamTinh { get; set; }

    [Column("fTienCoc", TypeName = "decimal(10, 2)")]
    public decimal? FTienCoc { get; set; }

    [Column("sTrangThai")]
    [StringLength(20)]
    public string? STrangThai { get; set; }

    [Column("dNgayTao", TypeName = "datetime")]
    public DateTime? DNgayTao { get; set; }

    [Column("dNgayHuy", TypeName = "datetime")]
    public DateTime? DNgayHuy { get; set; }

    [ForeignKey("FkIKhachhang")]
    [InverseProperty("TbDonDatXes")]
    public virtual TbKhachhang? FkIKhachhangNavigation { get; set; }

    [ForeignKey("FkIXe")]
    [InverseProperty("TbDonDatXes")]
    public virtual TbXe? FkIXeNavigation { get; set; }

    [InverseProperty("FkIDonDatNavigation")]
    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
