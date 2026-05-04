using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace Erp.Application.MascoWash.Queries
{
    public class BatchPrepareEditQuery : IRequest<List<BatchPrepareEditDto>>
    {
        public int UnitId { get; }
        public int BuyerId { get; }
        public int JobId { get; }
        public int StyleId { get; }
        public int OrderId { get; }

        public BatchPrepareEditQuery(int unitId, int buyerId, int jobId, int styleId, int orderId)
        {
            UnitId = unitId;
            BuyerId = buyerId;
            JobId = jobId;
            StyleId = styleId;
            OrderId = orderId;
        }
    }
}

