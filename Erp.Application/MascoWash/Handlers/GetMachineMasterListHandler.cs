using System;
using System.Collections.Generic;
using System.Text;

using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;

using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{

    public class GetMachineMasterListHandler
        : IRequestHandler<GetMachineMasterListQuery, List<MachineMasterDetailModel>>
    {
        private readonly ISaveDataList _setupService;

        public GetMachineMasterListHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<List<MachineMasterDetailModel>> Handle(
            GetMachineMasterListQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetMachineMasterList();
        }
    }

}
