using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Application.MascoWash.Handlers
{
    public class DateWiseQCPassDHUDashboardHandler
        : IRequestHandler<
            DateWiseQCPassDHUDashboardQuery,
            List<DateWiseQCPassDHUDashboardResponseDtos>>
    {
        private readonly ISaveDataList _setupService;


        public DateWiseQCPassDHUDashboardHandler(
            ISaveDataList setupService)
        {
            _setupService = setupService;
        }


        public async Task<List<DateWiseQCPassDHUDashboardResponseDtos>> Handle(
            DateWiseQCPassDHUDashboardQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetDateWiseQCPassDHUDashboard(
                request.UnitId,
                request.FromDate,
                request.ToDate
            );
        }
    }
}