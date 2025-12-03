using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class OperationNameEntryGetHandler : IRequestHandler<OperationNameEntryGet, List<OperationNameEntryGetList>>
    {
        private readonly ISaveDataList _setupservice;
        public OperationNameEntryGetHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<OperationNameEntryGetList>> Handle(OperationNameEntryGet request, CancellationToken cancellationToken)
        {
            return _setupservice.GetOperationNameEntryList();
        }
    }
}
