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
    public class StyleUnitBuyerJobWiseDDLHandler : IRequestHandler<StyleUnitBuyerJobWiseDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;
        public StyleUnitBuyerJobWiseDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<DropdownListDto1>> Handle(StyleUnitBuyerJobWiseDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetStyleDDLListData(request.UnitId, request.BuyerId,request.JobId);
        }
    }
   
}

