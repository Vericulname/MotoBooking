using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ApiRespone
    {
        private String message { get; set; }
        private Object data { get; set; }
        public ApiRespone(String message,Object data) {
            this.message = message;
            this.data = data;
        }
    }
}
