using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public partial class EmployeesModel
    {
        public int PkINhanvien { get; set; }

        public string SHoTen { get; set; } = null!;

        public DateTime? DNgayTao { get; set; }

    }
}
