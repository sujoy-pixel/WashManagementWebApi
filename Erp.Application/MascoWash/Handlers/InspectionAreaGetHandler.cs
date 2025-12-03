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
    public class InspectionAreaGetHandler : IRequestHandler<InspectionAreaGet, List<InspectionAreaGetList>>
    {
        private readonly ISaveDataList _setupservice;
        public InspectionAreaGetHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<InspectionAreaGetList>> Handle(InspectionAreaGet request, CancellationToken cancellationToken)
        {
            return _setupservice.GetInspectionAreaList();
        }
    }
}
