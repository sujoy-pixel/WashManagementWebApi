using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    public class StyleWiseQCPassDHUDashboardQuery
        : IRequest<List<StyleWiseQCPassDHUDashboardResponseDtos>>,
          IBaseRequest
    {
        public int UnitId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }


        public StyleWiseQCPassDHUDashboardQuery(
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