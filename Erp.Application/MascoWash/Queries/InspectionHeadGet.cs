using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class InspectionHeadGet : IRequest<List<InspectionHeadGetList>>
    {
    }

    public class InspectionHeadGetList
    {
        public int InspectionHeadId { get; set; }
        public string HeadName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
