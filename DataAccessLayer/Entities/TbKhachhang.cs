using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities;

public partial class TbKhachhang
{
    public int PkIKhachhang { get; set; }

    public string SHoTen { get; set; } = null!;

    public string SSoDienThoai { get; set; } = null!;

    public string? SCccd { get; set; }

    public string? SEmail { get; set; }

    public string? SDiaChi { get; set; }

    public DateTime? DNgayTao { get; set; }

    public virtual ICollection<TbDonDatXe> TbDonDatXes { get; set; } = new List<TbDonDatXe>();

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
