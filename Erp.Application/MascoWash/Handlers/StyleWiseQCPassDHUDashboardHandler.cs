using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Application.MascoWash.Handlers
{
    public class StyleWiseQCPassDHUDashboardHandler
        : IRequestHandler<
            StyleWiseQCPassDHUDashboardQuery,
            List<StyleWiseQCPassDHUDashboardResponseDtos>>
    {
        private readonly ISaveDataList _setupService;


        public StyleWiseQCPassDHUDashboardHandler(
            ISaveDataList setupService)
        {
            _setupService = setupService;
        }


        public async Task<List<StyleWiseQCPassDHUDashboardResponseDtos>> Handle(
            StyleWiseQCPassDHUDashboardQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetStyleWiseQCPassDHUDashboard(
                request.UnitId,
                request.FromDate,
                request.ToDate
            );
        }
    }
}