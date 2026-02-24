

using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class GetBatchPriorityDataQuery : IRequest<List<GetBatchPriorityDto>>
    {
        public int UnitId { get; }
        public string Date { get; }
  


        public GetBatchPriorityDataQuery(int unitId, string date)
        {
            UnitId = unitId;
            Date = date;

        }
    }
}





