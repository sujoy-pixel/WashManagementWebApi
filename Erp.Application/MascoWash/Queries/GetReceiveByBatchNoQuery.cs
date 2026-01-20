using MediatR;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    public class GetReceiveByBatchNoQuery
        : IRequest<List<TrackingNoWiseReceiveDto>>
    {
        public string BatchNo { get; }

        public GetReceiveByBatchNoQuery(string batchNo)
        {
            BatchNo = batchNo;
        }
    }
}
