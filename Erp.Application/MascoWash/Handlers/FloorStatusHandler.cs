using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Application.MascoWash.Handlers
{
    public class FloorStatusHandler
        : IRequestHandler<
            FloorStatusQuery,
            List<FloorStatusResponseDtos>>
    {
        private readonly ISaveDataList _setupService;


        public FloorStatusHandler(
            ISaveDataList setupService)
        {
            _setupService = setupService;
        }


        public async Task<List<FloorStatusResponseDtos>> Handle(
            FloorStatusQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetFloorStatusData(
                request.UnitId,
                request.FromDate,
                request.ToDate,
                request.OrderType
            );
        }
    }
}