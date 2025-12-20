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
    public class StyleDDLHandler : IRequestHandler<StyleDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public StyleDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(StyleDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetStyleDDLList(request.ItemText);
        }
    }
}
