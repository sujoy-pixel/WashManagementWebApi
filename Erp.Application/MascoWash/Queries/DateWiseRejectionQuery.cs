
using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    /// <summary>
    /// Mediator query for the Style-wise Rejection dashboard.
    /// Mirrors SP_Get_StyleWiseRejectionData parameters.
    /// </summary>
    public class DateWiseRejectionQuery
        : IRequest<List<DateWiseRejectionResponseDto>>,
          IBaseRequest
    {
        public int UnitId { get; set; }
        public int BuyerId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public DateWiseRejectionQuery(
            int unitId,
            int buyerId,
            DateTime fromDate,
            DateTime toDate)
        {
            UnitId = unitId;
            BuyerId = buyerId;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
