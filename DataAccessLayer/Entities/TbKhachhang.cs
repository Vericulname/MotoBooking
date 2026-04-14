using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tbKhachhang")]
[Index("SSoDienThoai", Name = "UQ__tbKhachh__B6E2FD9DA206C5E8", IsUnique = true)]
public partial class TbKhachhang
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

    [InverseProperty("FkIKhachhangNavigation")]
    public virtual ICollection<TbDonDatXe> TbDonDatXes { get; set; } = new List<TbDonDatXe>();

    [InverseProperty("FkIKhachhangNavigation")]
    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
