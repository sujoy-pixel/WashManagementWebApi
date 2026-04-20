
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class BatchWishStartEndDataHandler : IRequestHandler<BatchWiseStartEndDataQuery, List<BatchWishQCDataDto>>
    {
        private readonly ISaveDataList _setupService;
        public BatchWishStartEndDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<BatchWishQCDataDto>> Handle(
     BatchWiseStartEndDataQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetBatchWishStartEndDataList(request.batchNo);

        }
    }
}

