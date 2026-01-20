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
    public class GetWashBatchPrepareGridDataHandler : IRequestHandler<GetWashBatchPrepareGridQuery, List<TrackingNoWiseReceiveDto>>
    {
        private readonly ISaveDataList _setupService;
        public GetWashBatchPrepareGridDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<TrackingNoWiseReceiveDto>> Handle(
     GetWashBatchPrepareGridQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetBatchPrepareDataList(request.UnitId,request.BuyerId,request.JobId,request.StyleId,request.OrderId);

        }
    }
}
