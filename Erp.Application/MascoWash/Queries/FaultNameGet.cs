using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class FaultNameGet : IRequest<List<FaultNameGetList>>
    {
    }

    public class FaultNameGetList
    {
        public int FaultNameId { get; set; }
        public string FaultName { get; set; }
        public int FaultHeadId { get; set; }
        public string FaultHeadName { get; set; }
        public int CodeNo { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
