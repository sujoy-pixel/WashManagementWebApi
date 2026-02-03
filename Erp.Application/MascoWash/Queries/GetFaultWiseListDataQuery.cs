
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class GetFaultWiseListDataQuery : IRequest<List<GetFaultWiseListDto>>
    {
        public int InspectionTypeId { get; }
        public int InspectionHeadId { get; }
        public int FaultHeadId { get; }
    

        public GetFaultWiseListDataQuery(int inspectionTypeId, int inspectionHeadId, int faultHeadId)
        {
            InspectionTypeId = inspectionTypeId;
            InspectionHeadId = inspectionHeadId;
            FaultHeadId = faultHeadId;
         
        }
    }
}

