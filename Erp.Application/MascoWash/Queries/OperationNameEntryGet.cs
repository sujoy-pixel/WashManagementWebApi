using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class OperationNameEntryGet : IRequest<List<OperationNameEntryGetList>>
    {
    }

    public class OperationNameEntryGetList
    {
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
