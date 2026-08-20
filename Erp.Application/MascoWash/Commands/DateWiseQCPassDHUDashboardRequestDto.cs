using System;

namespace Erp.Application.MascoWash.Queries
{
    public class DateWiseQCPassDHUDashboardRequestDto
    {
        public int UnitId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}