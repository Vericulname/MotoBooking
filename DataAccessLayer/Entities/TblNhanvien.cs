using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblNhanvien")]
public partial class TblNhanvien
{
    [Key]
    [Column("PK_iNhanvien")]
    public int PkINhanvien { get; set; }

    [Column("sHoTen")]
    [StringLength(100)]
    public string SHoTen { get; set; } = null!;

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
