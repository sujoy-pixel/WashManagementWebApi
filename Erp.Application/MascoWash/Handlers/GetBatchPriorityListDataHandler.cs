
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
    public class GetBatchPriorityListDataHandler : IRequestHandler<GetBatchPriorityDataQuery, List<GetBatchPriorityDto>>
    {
        private readonly ISaveDataList _setupService;
        public GetBatchPriorityListDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<GetBatchPriorityDto>> Handle(
     GetBatchPriorityDataQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetPrioritySetDataList(request.UnitId, request.Date);

        }
    }
}

