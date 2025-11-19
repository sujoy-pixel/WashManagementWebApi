using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Requests.ErpApp.External_API_Factory
{
    public class DailyAttendanceDto
    {
        public int CDate { get; set; }
        public string InTime { get; set; }
        public string CName { get; set; }
        public string CUnique { get; set; }
        public string OutTime { get; set; }
    }
}

