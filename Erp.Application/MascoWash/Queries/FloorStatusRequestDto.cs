using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Erp.Application.MascoWash.Queries
{
    public class FloorStatusRequestDto
    {
        public int UnitId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string OrderType { get; set; }
    }
}