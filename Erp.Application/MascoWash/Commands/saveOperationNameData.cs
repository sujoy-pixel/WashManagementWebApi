using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class saveOperationNameData : IRequest<WrapperResponseOperationName>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Operation { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
    public class WrapperResponseOperationName
    {
        public string ResultCode { get; set; }
    }
}
