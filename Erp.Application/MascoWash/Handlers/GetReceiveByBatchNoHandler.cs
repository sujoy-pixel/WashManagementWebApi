

using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class GetReceiveByBatchNoHandler
        : IRequestHandler<GetReceiveByBatchNoQuery, List<TrackingNoWiseReceiveDto>>
    {
        private readonly ISaveDataList _setupService;

        public GetReceiveByBatchNoHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<List<TrackingNoWiseReceiveDto>> Handle(
            GetReceiveByBatchNoQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetReceiveDataListBatchNo(request.BatchNo);

        }
    }
}
