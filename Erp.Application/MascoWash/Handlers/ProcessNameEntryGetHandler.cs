
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class ProcessNameEntryGetHandler : IRequestHandler<ProcessNameEntryGet, List<ProcessNameEntryGetList>>
    {
        private readonly ISaveDataList _setupservice;
        public ProcessNameEntryGetHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<ProcessNameEntryGetList>> Handle(ProcessNameEntryGet request, CancellationToken cancellationToken)
        {
            return _setupservice.GetProcessNameEntryList();
        }
    }
}
