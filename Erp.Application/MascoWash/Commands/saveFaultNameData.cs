using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class saveFaultNameData : IRequest<WrapperResponseFaultName>
    {

        public string Operation { get; set; }
        public int FaultNameId { get; set; }
        public string FaultName { get; set; }
        public int FaultHeadId { get; set; }
        public int CodeNo { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
    public class WrapperResponseFaultName
    {
        public string ResultCode { get; set; }
    }
}
