using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class FaultHeadDDLHandler : IRequestHandler<FaultHeadDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public FaultHeadDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(FaultHeadDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetFaultHeadDDLList();
        }
    }
}
