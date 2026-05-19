
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
    public class getBatchWishAsidPrepareDataHandler : IRequestHandler<getBatchWishAsidPrepareDataDataQuery, List<BatchWishQCDataDto>>
    {
        private readonly ISaveDataList _setupService;
        public getBatchWishAsidPrepareDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<BatchWishQCDataDto>> Handle(
     getBatchWishAsidPrepareDataDataQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetBatchWishAcidWashPrepareList(request.batchNo);

        }
    }
}

