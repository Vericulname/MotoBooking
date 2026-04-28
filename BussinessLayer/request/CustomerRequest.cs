using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.request
{
    public class CustomerRequest
    {


        public string SHoTen { get; set; } = null!;

        public string SSoDienThoai { get; set; } = null!;

        //public string SMatKhau { get; set; } = null!;
        public string? SCccd { get; set; }

        public string? SEmail { get; set; }

        public string? SDiaChi { get; set; }


    }
}
