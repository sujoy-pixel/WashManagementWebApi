using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class DetailDto
    {
        public int ResultCode { get; set; }
        public int MasterId { get; set; }
        public string ReceiveNo { get; set; }
        public string Message { get; set; }
    }

}
