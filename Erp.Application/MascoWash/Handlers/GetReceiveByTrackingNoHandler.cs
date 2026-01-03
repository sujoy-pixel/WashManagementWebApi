using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class GetReceiveByTrackingNoHandler
        : IRequestHandler<GetReceiveByTrackingNoQuery, List<TrackingNoWiseReceiveDto>>
    {
        private readonly ISaveDataList _setupService;

        public GetReceiveByTrackingNoHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<List<TrackingNoWiseReceiveDto>> Handle(
            GetReceiveByTrackingNoQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetReceiveDataList(request.TrackingNo);
            
        }
    }
}
