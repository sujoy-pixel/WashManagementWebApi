
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
    public class GetProcessNameDDLHandler : IRequestHandler<ProcessNameDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public GetProcessNameDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(ProcessNameDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetProcessNameList();
        }
    }
}
