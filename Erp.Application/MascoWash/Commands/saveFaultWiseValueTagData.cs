using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Commands
{
    public class saveFaultWiseValueTagData : IRequest<WrapperResponseFaultWiseValueTag>
    {
        public string Operation { get; set; }          // INSERT / UPDATE / DELETE
        public int FaultWiseMasterId { get; set; }
        public string Type { get; set; }
        public int InspectionHeadId { get; set; }
        public int FaultHeadId { get; set; }
        public int CreatedBy { get; set; }
        public List<FaultWiseValueTagDetailDto> FaultWiseDetails { get; set; }
    }
    public class FaultWiseValueTagDetailDto
    {
        public int FaultWiseMasterId { get; set; }
        public int FaultNameId { get; set; }
        public decimal Value { get; set; }
        public bool IsChecked { get; set; }
    }

    public class WrapperResponseFaultWiseValueTag
    {
        public string ResultCode { get; set; }
    }


}
