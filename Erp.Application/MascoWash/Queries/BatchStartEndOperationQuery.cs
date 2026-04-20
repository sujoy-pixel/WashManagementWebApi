
using MediatR;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    public class BatchStartEndOperationQuery : IRequest<List<WashStartEndResponseDtos>>, IBaseRequest
    {
        public string BatchNo { get; set; }

        public BatchStartEndOperationQuery(string batchNo)
        {
            BatchNo = batchNo;
        }
    }
}