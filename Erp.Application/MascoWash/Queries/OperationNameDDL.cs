using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class OperationNameDDL : IRequest<List<DropdownListDto1>>
    {
    }

    public class OperationNameDDLList
    {
        public int OperationId { get; set; }
        public string OperationName { get; set; }
    }
}
