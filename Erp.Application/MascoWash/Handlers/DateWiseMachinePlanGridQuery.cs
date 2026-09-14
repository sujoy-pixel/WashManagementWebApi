using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class DateWiseMachinePlanGridQuery
        : IRequest<List<DateWiseMachinePlanGridResponseDto>>, IBaseRequest
    {
        public int? UnitId { get; set; }
        public int BuyerId { get; set; }
        public int? JobId { get; set; }
        public int StyleId { get; set; }
        public int? OrderId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public DateWiseMachinePlanGridQuery(int? unitId, int buyerId, int? jobId, int styleId, int? orderId, DateTime fromDate, DateTime toDate)
        {
            UnitId = unitId;
            BuyerId = buyerId;
            JobId = jobId;
            StyleId = styleId;
            OrderId = orderId;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }

    public class DateWiseMachinePlanGridHandler
        : IRequestHandler<DateWiseMachinePlanGridQuery, List<DateWiseMachinePlanGridResponseDto>>
    {
        private readonly ISaveDataList _setupService;
        public DateWiseMachinePlanGridHandler(ISaveDataList setupService) => _setupService = setupService;

        public async Task<List<DateWiseMachinePlanGridResponseDto>> Handle(
            DateWiseMachinePlanGridQuery request, CancellationToken cancellationToken)
            => await _setupService.GetDateWiseMachinePlanGrid(
                request.UnitId, request.BuyerId, request.JobId, request.StyleId, request.OrderId,
                request.FromDate, request.ToDate);
    }
}
