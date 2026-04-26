using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Commands
{
    public class saveProcessNameData : IRequest<WrapperResponseProcessName>
    {

        public string Operation { get;set; }
        public int OperationId { get; set; }
        public int ProcessId { get; set; }
        public int UnitId { get; set; }
        public string ProcessName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
    public class WrapperResponseProcessName
    {
        public string ResultCode { get; set; }
    }
}

