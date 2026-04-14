using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

[Table("tbLoaiHuHong")]
public partial class TbLoaiHuHong
{
    [Key]
    [Column("PK_iLoaiHuHong")]
    public int PkILoaiHuHong { get; set; }

    [Column("sTenHuHong")]
    [StringLength(100)]
    public string STenHuHong { get; set; } = null!;

    [Column("fPhiPhat")]
    [StringLength(100)]
    public string FPhiPhat { get; set; } = null!;

    [InverseProperty("FkILoaiHuHongNavigation")]
    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
