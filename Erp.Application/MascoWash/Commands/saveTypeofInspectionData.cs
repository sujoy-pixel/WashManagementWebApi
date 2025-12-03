using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class saveTypeofInspectionData : IRequest<WrapperResponseTypeofInspection>
    {

        public string Operation { get; set; }
        public int TypeofInspectionId { get; set; }
        public string TypeName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
    public class WrapperResponseTypeofInspection
    {
        public string ResultCode { get; set; }
    }
}
