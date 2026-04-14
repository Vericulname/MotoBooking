using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tbNhanvien")]
[Index("SSoDienThoai", Name = "UQ__tbNhanvi__B6E2FD9DF5A449B3", IsUnique = true)]
public partial class TbNhanvien
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

    [InverseProperty("FkINhanvienNavigation")]
    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
