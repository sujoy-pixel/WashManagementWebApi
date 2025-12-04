using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class FaultHeadGet : IRequest<List<FaultHeadGetList>>
    {
    }

    public class FaultHeadGetList
    {
        public int FaultHeadId { get; set; }
        public int CodeNo { get; set; }
        public string FaultHeadName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
