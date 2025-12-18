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
    public class BuyerDDLHandler : IRequestHandler<BuyerDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;

        public BuyerDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<DropdownListDto1>> Handle(BuyerDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetBuyerDDLList();
        }
    }
}
