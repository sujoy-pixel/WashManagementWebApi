using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class InspectionAreaGet : IRequest<List<InspectionAreaGetList>>
    {
    }

    public class InspectionAreaGetList
    {
        public int InspectionAreaId { get; set; }
        public string InspectionArea { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
