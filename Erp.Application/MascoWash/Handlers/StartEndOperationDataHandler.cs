using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Application.MascoWash.Handlers
{
    public class StartEndOperationDataHandler
        : IRequestHandler<BatchStartEndOperationQuery, List<WashStartEndResponseDtos>>
    {
        private readonly ISaveDataList _setupService;

        public StartEndOperationDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<List<WashStartEndResponseDtos>> Handle(
            BatchStartEndOperationQuery request,
            CancellationToken cancellationToken)
        {
            // ✅ FIX: BatchNo (capital B)
            return await _setupService.GetStartEndOperationData(request.BatchNo);
        }
    }
}