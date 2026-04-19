using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class DamageTypesModel
    {
        public int PkILoaiHuHong { get; set; }

        public string STenHuHong { get; set; } = null!;

        public string FPhiPhat { get; set; } = null!;
    }
}
