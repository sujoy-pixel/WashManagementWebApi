using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    public class DateWiseQCPassDHUDashboardQuery
        : IRequest<List<DateWiseQCPassDHUDashboardResponseDtos>>,
          IBaseRequest
    {
        public int UnitId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }


        public DateWiseQCPassDHUDashboardQuery(
            int unitId,
            DateTime fromDate,
            DateTime toDate)
        {
            UnitId = unitId;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}