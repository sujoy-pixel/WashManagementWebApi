
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
    public class GetFaultWiseListDataHandler : IRequestHandler<GetFaultWiseListDataQuery, List<GetFaultWiseListDto>>
    {
        private readonly ISaveDataList _setupService;
        public GetFaultWiseListDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<GetFaultWiseListDto>> Handle(
     GetFaultWiseListDataQuery request,
     CancellationToken cancellationToken)
        {
            return await _setupService.GetFaultWiseListDataList(request.InspectionTypeId,request.InspectionHeadId,request.FaultHeadId);

        }
    }
}

