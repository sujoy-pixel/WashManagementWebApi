using MediatR;
using System;
using System.Collections.Generic;
using System.Text;



namespace Erp.Application.MascoWash.Queries
{
    public class StyleUnitBuyerJobWiseDDL : IRequest<List<DropdownListDto1>>
    {
        public int UnitId { get; }
        public int BuyerId { get; }
        public int JobId { get; }

        public StyleUnitBuyerJobWiseDDL(int unitId, int buyerId, int jobId)
        {
            UnitId = unitId;
            BuyerId = buyerId;
            JobId = jobId;
        }


    }
}
