using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TbNhanvien
{
    public int PkINhanvien { get; set; }

    public string SHoTen { get; set; } = null!;

    public string SSoDienThoai { get; set; } = null!;

    public string SMatKhau { get; set; } = null!;

    public string? SVaiTro { get; set; }

    public DateTime? DNgayTao { get; set; }

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
