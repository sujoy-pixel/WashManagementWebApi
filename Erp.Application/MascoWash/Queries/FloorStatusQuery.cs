using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    public class FloorStatusQuery
        : IRequest<List<FloorStatusResponseDtos>>, IBaseRequest
    {
        public int UnitId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string OrderType { get; set; }


        public FloorStatusQuery(
            int unitId,
            DateTime fromDate,
            DateTime toDate,
            string orderType)
        {
            UnitId = unitId;
            FromDate = fromDate;
            ToDate = toDate;
            OrderType = orderType;
        }
    }
}