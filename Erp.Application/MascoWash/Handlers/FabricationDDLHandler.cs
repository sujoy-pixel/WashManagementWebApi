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
    public class FabricationDDLHandler : IRequestHandler<FabricationDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public FabricationDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(FabricationDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetFabricationDDLList(request.ItemText);
        }
    }
}
