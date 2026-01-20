using Erp.Application.MascoWash.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class JobUnitBuyerDDL : IRequest<List<DropdownListDto1>>
    {
        public int UnitId { get; }
        public int BuyerId { get; }

        public JobUnitBuyerDDL(int unitId, int buyerId)
        {
            UnitId = unitId;
            BuyerId = buyerId;
        }


    }
}
