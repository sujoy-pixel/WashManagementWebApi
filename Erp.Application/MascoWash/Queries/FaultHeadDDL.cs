using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class FaultHeadDDL : IRequest<List<DropdownListDto1>>
    {
    }

    public class FaultHeadDDLList
    {
        public int FaultHeadId { get; set; }
        public string FaultHeadName { get; set; }
    }
}
