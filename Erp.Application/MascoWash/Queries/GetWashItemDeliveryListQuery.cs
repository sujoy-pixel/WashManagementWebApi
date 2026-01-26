
using Erp.Application.MascoWash.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class GetWashItemDeliveryListQuery : IRequest<List<TrackingNoWiseReceiveDto>>
    {
        public int UnitId { get; }
        public string FromDate { get; }
        public string ToDate { get; }
        public string TrackingBatchNo { get; }

        public GetWashItemDeliveryListQuery(int unitId, string fromDate, string toDate, string trackingBatchNo)
        {
            UnitId = unitId;
            FromDate = fromDate;
            ToDate = toDate;
            TrackingBatchNo = trackingBatchNo;
           
        }
    }
}

