using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblNhanvien")]
[Index("SSoDienThoai", Name = "UQ__tblNhanv__B6E2FD9D1F835862", IsUnique = true)]
public partial class TblNhanvien
{
    [Key]
    [Column("PK_iNhanvien")]
    public int PkINhanvien { get; set; }

    [Column("sHoTen")]
    [StringLength(100)]
    public string SHoTen { get; set; } = null!;

    [Column("sSoDienThoai")]
    [StringLength(15)]
    [Unicode(false)]
    public string SSoDienThoai { get; set; } = null!;

    [Column("sMatKhau")]
    [StringLength(255)]
    [Unicode(false)]
    public string SMatKhau { get; set; } = null!;

    [Column("sVaiTro")]
    [StringLength(20)]
    public string? SVaiTro { get; set; }

    [Column("dNgayTao", TypeName = "datetime")]
    public DateTime? DNgayTao { get; set; }

    [Column("Fk_iTaiKhoan")]
    public int? FkITaiKhoan { get; set; }

    [ForeignKey("FkITaiKhoan")]
    [InverseProperty("TblNhanviens")]
    public virtual TblTaiKhoan? FkITaiKhoanNavigation { get; set; }

    [InverseProperty("FkINhanvienNavigation")]
    public virtual ICollection<TblHopDong> TblHopDongs { get; set; } = new List<TblHopDong>();
}
