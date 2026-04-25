using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessLayer.request
{
    public class RegisterCustomerRequest
    {
        public string SMatKhau { get; set; } = null!;
        public string SHoTen { get; set; } = null!;

        public string SSoDienThoai { get; set; } = null!;


        public string? SVaiTro { get;  } = "customer";
    }
}
