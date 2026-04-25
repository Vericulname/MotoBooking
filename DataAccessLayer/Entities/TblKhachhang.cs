using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblKhachhang")]
[Index("SSoDienThoai", Name = "UQ__tblKhach__B6E2FD9DBAC4BC74", IsUnique = true)]
public partial class TblKhachhang
{
    [Key]
    [Column("PK_iKhachhang")]
    public int PkIKhachhang { get; set; }

    [Column("sHoTen")]
    [StringLength(100)]
    public string SHoTen { get; set; } = null!;

    [Column("sSoDienThoai")]
    [StringLength(15)]
    [Unicode(false)]
    public string SSoDienThoai { get; set; } = null!;

    [Column("sCCCD")]
    [StringLength(12)]
    [Unicode(false)]
    public string? SCccd { get; set; }

    [Column("sEmail")]
    [StringLength(100)]
    public string? SEmail { get; set; }

    [Column("sDiaChi")]
    [StringLength(200)]
    public string? SDiaChi { get; set; }

    [Column("dNgayTao", TypeName = "datetime")]
    public DateTime? DNgayTao { get; set; }

    [Column("Fk_iTaiKhoan")]
    public int? FkITaiKhoan { get; set; }

    [ForeignKey("FkITaiKhoan")]
    [InverseProperty("TblKhachhangs")]
    public virtual TblTaiKhoan? FkITaiKhoanNavigation { get; set; }

    [InverseProperty("FkIKhachhangNavigation")]
    public virtual ICollection<TblDonDatXe> TblDonDatXes { get; set; } = new List<TblDonDatXe>();

    [InverseProperty("FkIKhachhangNavigation")]
    public virtual ICollection<TblHopDong> TblHopDongs { get; set; } = new List<TblHopDong>();
}
