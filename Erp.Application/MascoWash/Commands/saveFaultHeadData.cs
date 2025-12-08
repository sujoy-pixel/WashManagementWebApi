using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class saveFaultHeadData : IRequest<WrapperResponseFaultHead>
    {

        public string Operation { get; set; }
        public int FaultHeadId { get; set; }
        public int CodeNo { get; set; }
        public string FaultHeadName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
    public class WrapperResponseFaultHead
    {
        public string ResultCode { get; set; }
    }
}
