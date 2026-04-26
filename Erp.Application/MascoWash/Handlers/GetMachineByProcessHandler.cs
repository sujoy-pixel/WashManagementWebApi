
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class GetMachineByProcessHandler
        : IRequestHandler<GetMachineByProcessQuery, List<GetMachineByProcessDto>>
    {
        private readonly ISaveDataList _setupservice;


        public GetMachineByProcessHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public async Task<List<GetMachineByProcessDto>> Handle( GetMachineByProcessQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupservice.GetMachineByProcess(request.ProcessIds);
        }
    }
}
