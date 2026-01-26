
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
    public class GetWashItemDeliveryListOfDataHandler : IRequestHandler<GetWashItemDeliveryListQuery, List<TrackingNoWiseReceiveDto>>
    {
        private readonly ISaveDataList _setupService;
        public GetWashItemDeliveryListOfDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<TrackingNoWiseReceiveDto>> Handle(
     GetWashItemDeliveryListQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetWashItemDeliveryList(request.UnitId, request.FromDate, request.ToDate, request.TrackingBatchNo);

        }
    }
}
