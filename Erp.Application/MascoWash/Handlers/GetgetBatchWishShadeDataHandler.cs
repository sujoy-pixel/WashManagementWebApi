
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
    public class GetgetBatchWishShadeDataHandler : IRequestHandler<BathchWiseShadeDataQuery, List<BatchWishQCDataDto>>
    {
        private readonly ISaveDataList _setupService;
        public GetgetBatchWishShadeDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<BatchWishQCDataDto>> Handle(
     BathchWiseShadeDataQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetBatchWishShadeDataList(request.batchNo);

        }
    }
}

