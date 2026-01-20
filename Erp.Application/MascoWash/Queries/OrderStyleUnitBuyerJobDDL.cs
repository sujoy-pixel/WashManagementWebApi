using Erp.Application.MascoWash.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

public class OrderStyleUnitBuyerJobDDL : IRequest<List<DropdownListDto1>>
{
    public int UnitId { get; }
    public int BuyerId { get; }
    public int JobId { get; }
    public int StyleId { get; }

    public OrderStyleUnitBuyerJobDDL(int unitId, int buyerId, int jobId, int styleId)
    {
        UnitId = unitId;
        BuyerId = buyerId;
        JobId = jobId;
        StyleId = styleId;
    }


}
