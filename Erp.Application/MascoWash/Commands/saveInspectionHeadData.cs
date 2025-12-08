using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class saveInspectionHeadData : IRequest<WrapperResponseInspectionHead>
    {

        public string Operation { get; set; }
        public int InspectionHeadId { get; set; }
        public string HeadName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
    public class WrapperResponseInspectionHead
    {
        public string ResultCode { get; set; }
    }
}
