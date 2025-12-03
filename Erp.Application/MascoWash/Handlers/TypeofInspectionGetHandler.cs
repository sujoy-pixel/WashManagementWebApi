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
    public class TypeofInspectionGetHandler : IRequestHandler<TypeofInspectionGet, List<TypeofInspectionGetList>>
    {
        private readonly ISaveDataList _setupservice;
        public TypeofInspectionGetHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public Task<List<TypeofInspectionGetList>> Handle(TypeofInspectionGet request, CancellationToken cancellationToken)
        {
            return _setupservice.GetTypeofInspectionList();
        }
    }
}
