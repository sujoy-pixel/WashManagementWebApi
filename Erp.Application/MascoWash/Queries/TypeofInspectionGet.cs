using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class TypeofInspectionGet : IRequest<List<TypeofInspectionGetList>>
    {
    }

    public class TypeofInspectionGetList
    {
        public int TypeofInspectionId { get; set; }
        public string TypeName { get; set; }
        //public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
