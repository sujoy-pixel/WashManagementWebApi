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
    public class FaultWiseValueTagGetHandler : IRequestHandler<FaultWiseValueTagGet, List<FaultWiseValueTagDetailGetAll>>
    {
        private readonly ISaveDataList _setupservice;

        public FaultWiseValueTagGetHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<FaultWiseValueTagDetailGetAll>> Handle(FaultWiseValueTagGet request, CancellationToken cancellationToken)
        {
            return _setupservice.GetFaultWiseValueTagList();
        }
    }
}
