using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class saveInspectionAreaData : IRequest<WrapperResponseInspectionArea>
    {
        public string Operation { get; set; }
        public int InspectionAreaId { get; set; }
        public string InspectionArea { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
    public class WrapperResponseInspectionArea
    {
        public string ResultCode { get; set; }
    }
}
