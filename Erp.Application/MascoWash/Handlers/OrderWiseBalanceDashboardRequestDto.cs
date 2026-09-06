using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class OrderWiseBalanceDashboardQuery
    : IRequest<List<OrderWiseBalanceDashboardResponseDto>>, IBaseRequest
{
    public int UnitId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int ViewType { get; set; }        // 1 = Garments, 2 = Fabric

    public OrderWiseBalanceDashboardQuery(int unitId, DateTime fromDate, DateTime toDate, int viewType)
    { UnitId = unitId; FromDate = fromDate; ToDate = toDate; ViewType = viewType; }
}

public class OrderWiseBalanceDashboardHandler
    : IRequestHandler<OrderWiseBalanceDashboardQuery, List<OrderWiseBalanceDashboardResponseDto>>
{
    private readonly ISaveDataList _setupService;
    public OrderWiseBalanceDashboardHandler(ISaveDataList setupService) => _setupService = setupService;

    public async Task<List<OrderWiseBalanceDashboardResponseDto>> Handle(
        OrderWiseBalanceDashboardQuery request, CancellationToken cancellationToken)
        => await _setupService.GetOrderWiseBalanceDashboard(
            request.UnitId, request.FromDate, request.ToDate, request.ViewType);
}