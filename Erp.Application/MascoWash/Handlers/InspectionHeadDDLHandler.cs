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
    public class InspectionHeadDDLHandler : IRequestHandler<InspectionHeadDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public InspectionHeadDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(InspectionHeadDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetInspectionHeadDDLList();
        }
    }
}
