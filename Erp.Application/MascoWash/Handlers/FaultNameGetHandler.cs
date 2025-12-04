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
    public class FaultNameGetHandler : IRequestHandler<FaultNameGet, List<FaultNameGetList>>
    {
        private readonly ISaveDataList _setupservice;
        public FaultNameGetHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<FaultNameGetList>> Handle(FaultNameGet request, CancellationToken cancellationToken)
        {
            return _setupservice.GetFaultNameList();
        }
    }
}
