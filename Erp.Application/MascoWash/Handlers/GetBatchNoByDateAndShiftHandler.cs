using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Application.MascoWash.Handlers
{
    public class GetBatchNoByDateAndShiftHandler
        : IRequestHandler<
            GetBatchNoByDateAndShiftQuery,
            List<GetBatchNoByDateAndShiftDto>>
    {
        private readonly ISaveDataList _setupService;

        public GetBatchNoByDateAndShiftHandler(
            ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<List<GetBatchNoByDateAndShiftDto>> Handle(
            GetBatchNoByDateAndShiftQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetBatchNoByDateAndShift(
                request.Date,
                request.ShiftId
            );
        }
    }
}