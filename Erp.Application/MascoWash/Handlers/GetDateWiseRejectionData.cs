


using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Application.MascoWash.Handlers
{
    /// <summary>
    /// Mediator handler for the Style-wise Rejection dashboard.
    /// Just forwards the query to the repository, which executes
    /// [dbo].[SP_Get_StyleWiseRejectionData] and projects the
    /// dynamic-column result into StyleWiseRejectionResponseDto.
    /// </summary>
    public class GetDateWiseRejectionData
        : IRequestHandler<
            DateWiseRejectionQuery,
            List<DateWiseRejectionResponseDto>>
    {
        private readonly ISaveDataList _setupService;

        public GetDateWiseRejectionData(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<List<DateWiseRejectionResponseDto>> Handle(
            DateWiseRejectionQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetDateWiseRejectionData(
                request.UnitId,
                request.BuyerId,
                request.FromDate,
                request.ToDate
            );
        }
    }
}
