using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tblLoaiHuHong")]
public partial class TblLoaiHuHong
{
    [Key]
    [Column("PK_iLoaiHuHong")]
    public int PkILoaiHuHong { get; set; }

    [Column("sTenHuHong")]
    [StringLength(100)]
    public string STenHuHong { get; set; } = null!;

    [Column("fPhiPhat", TypeName = "decimal(10, 2)")]
    public decimal FPhiPhat { get; set; }

    [InverseProperty("FkILoaiHuHongNavigation")]
    public virtual ICollection<TblHoaDon> TblHoaDons { get; set; } = new List<TblHoaDon>();
}
