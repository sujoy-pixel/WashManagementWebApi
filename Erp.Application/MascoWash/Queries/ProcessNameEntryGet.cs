using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class ProcessNameEntryGet : IRequest<List<ProcessNameEntryGetList>>
    {
    }

    public class ProcessNameEntryGetList
    {
        public int ProcessId { get; set; }
        public int UnitId { get; set; }
        public string UnitEName { get; set; }
        public string ProcessName { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
