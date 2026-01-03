using MediatR;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    public class GetReceiveByTrackingNoQuery
        : IRequest<List<TrackingNoWiseReceiveDto>>
    {
        public string TrackingNo { get; }

        public GetReceiveByTrackingNoQuery(string trackingNo)
        {
            TrackingNo = trackingNo;
        }
    }
}
