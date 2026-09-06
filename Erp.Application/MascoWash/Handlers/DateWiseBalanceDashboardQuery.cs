using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class DateWiseBalanceDashboardQuery
    : IRequest<List<DateWiseBalanceDashboardResponseDto>>, IBaseRequest
{
    public int UnitId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int ViewType { get; set; }        // 1 = Garments, 2 = Fabric

    public DateWiseBalanceDashboardQuery(int unitId, DateTime fromDate, DateTime toDate, int viewType)
    { UnitId = unitId; FromDate = fromDate; ToDate = toDate; ViewType = viewType; }
}

public class DateWiseBalanceDashboardHandler
    : IRequestHandler<DateWiseBalanceDashboardQuery, List<DateWiseBalanceDashboardResponseDto>>
{
    private readonly ISaveDataList _setupService;
    public DateWiseBalanceDashboardHandler(ISaveDataList setupService) => _setupService = setupService;

    public async Task<List<DateWiseBalanceDashboardResponseDto>> Handle(
        DateWiseBalanceDashboardQuery request, CancellationToken cancellationToken)
        => await _setupService.GetDateWiseBalanceDashboard(
            request.UnitId, request.FromDate, request.ToDate, request.ViewType);
}