using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TbLoaiHuHong
{
    public int PkILoaiHuHong { get; set; }

    public string STenHuHong { get; set; } = null!;

    public string FPhiPhat { get; set; } = null!;

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
