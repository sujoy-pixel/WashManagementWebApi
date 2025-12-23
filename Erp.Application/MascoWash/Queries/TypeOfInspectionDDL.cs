using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class TypeOfInspectionDDL : IRequest<List<DropdownListDto1>>
    {
    }

    public class TypeOfInspectionDDLList
    {
        public int TypeofInspectionId { get; set; }
        public string TypeName { get; set; }
    }
}
