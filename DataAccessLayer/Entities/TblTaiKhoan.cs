using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblTaiKhoan")]
[Index("SSoDienThoai", Name = "UQ__tblTaiKh__B6E2FD9D678D5F9B", IsUnique = true)]
public partial class TblTaiKhoan
{
    [Key]
    [Column("PK_iTaiKhoan")]
    public int PkITaiKhoan { get; set; }

    [Column("sMatKhau")]
    [StringLength(255)]
    public string SMatKhau { get; set; } = null!;

    [Column("sSoDienThoai")]
    [StringLength(15)]
    [Unicode(false)]
    public string SSoDienThoai { get; set; } = null!;

    [Column("sVaiTro")]
    [StringLength(50)]
    public string SVaiTro { get; set; } = null!;

    [InverseProperty("FkITaiKhoanNavigation")]
    public virtual ICollection<TblKhachhang> TblKhachhangs { get; set; } = new List<TblKhachhang>();

    [InverseProperty("FkITaiKhoanNavigation")]
    public virtual ICollection<TblNhanvien> TblNhanviens { get; set; } = new List<TblNhanvien>();
}
