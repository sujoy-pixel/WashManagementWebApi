using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class InspectionHeadDDL : IRequest<List<DropdownListDto1>>
    {
    }

    public class InspectionHeadDDLList
    {
        public int InspectionHeadId { get; set; }
        public string HeadName { get; set; }
    }
}
