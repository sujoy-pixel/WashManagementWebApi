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
    public class FaultWiseValueTagGetByMasterIdHandler : IRequestHandler<FaultWiseValueTagGetByMasterId, List<FaultWiseValueTagDetailGetAll>>
    {
        private readonly ISaveDataList _setupservice;

        public FaultWiseValueTagGetByMasterIdHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public Task<List<FaultWiseValueTagDetailGetAll>> Handle(FaultWiseValueTagGetByMasterId request, CancellationToken cancellationToken)
        {
            return _setupservice.GetFaultWiseValueTagListByFaultWiseMasterId(request.FaultWiseMasterId);
        }
    }
}

