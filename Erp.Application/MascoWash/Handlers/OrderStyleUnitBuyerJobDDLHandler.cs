using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class OrderStyleUnitBuyerJobDDLHandler : IRequestHandler<OrderStyleUnitBuyerJobDDL, List<DropdownListDto1>>
    {
        private readonly ISaveDataList _setupservice;
        public OrderStyleUnitBuyerJobDDLHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<DropdownListDto1>> Handle(OrderStyleUnitBuyerJobDDL request, CancellationToken cancellationToken)
        {
            return _setupservice.GetOrderDDLListData(request.UnitId, request.BuyerId, request.JobId,request.StyleId);
        }
    }

}