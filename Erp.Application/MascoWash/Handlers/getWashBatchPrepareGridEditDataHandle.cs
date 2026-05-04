
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
    public class getWashBatchPrepareGridEditDataHandle : IRequestHandler<BatchPrepareEditQuery, List<BatchPrepareEditDto>>
    {
        private readonly ISaveDataList _setupService;
        public getWashBatchPrepareGridEditDataHandle(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<BatchPrepareEditDto>> Handle(
     BatchPrepareEditQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetBatchPrepareDataEditList(request.UnitId, request.BuyerId, request.JobId, request.StyleId, request.OrderId);

        }
    }
}
