using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.request
{
    public class RegisterAccRequest
    {
        public string SMatKhau { get; set; } = null!;
        public string SHoTen { get; set; } = null!;

        public string SSoDienThoai { get; set; } = null!;


        public string? SVaiTro { get; set; } 
    }
}
