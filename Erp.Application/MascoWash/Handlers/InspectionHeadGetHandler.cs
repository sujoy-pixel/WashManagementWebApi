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
    public class InspectionHeadGetHandler : IRequestHandler<InspectionHeadGet, List<InspectionHeadGetList>>
    {
        private readonly ISaveDataList _setupservice;
        public InspectionHeadGetHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<InspectionHeadGetList>> Handle(InspectionHeadGet request, CancellationToken cancellationToken)
        {
            return _setupservice.GetInspectionHeadList();
        }
    }
}
