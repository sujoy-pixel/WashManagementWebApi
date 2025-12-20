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
    public class DressPartDDLHandler : IRequestHandler<DressPartDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public DressPartDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(DressPartDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetDressPartDDLList(request.ItemText);
        }
    }
}
