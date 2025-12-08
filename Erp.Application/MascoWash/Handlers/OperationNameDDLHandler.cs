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
    public class OperationNameDDLHandler : IRequestHandler<OperationNameDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public OperationNameDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(OperationNameDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetOperationNameDDLList();
        }
    }
}
