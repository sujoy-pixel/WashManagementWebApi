
using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;





namespace Erp.Application.MascoWash.Commands
{

    public class SaveFaultWiseValueModel : IRequest<Result>
    {

        public int InspectionTypeId { get; set; }
        public int InspectionHeadId { get; set; }
        public int FaultHeadId { get; set; }
        public string CreatedBy { get; set; }

        public List<FaultWiseDetailDto> Details { get; set; }
    }

    public class FaultWiseDetailDto
    {
        public int FaultNameId { get; set; }
        public decimal FaultValue { get; set; }
        public bool IsActive { get; set; }



    }

}

