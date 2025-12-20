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
    public class GSMDDLHandler : IRequestHandler<GSMDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public GSMDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(GSMDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetGSMDDLList(request.ItemText);
        }
    }
}
