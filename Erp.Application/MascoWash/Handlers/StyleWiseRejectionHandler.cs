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
        public class StyleWiseRejectionHandler
            : IRequestHandler<
                StyleWiseRejectionQuery,
                List<StyleWiseRejectionResponseDto>>
        {
            private readonly ISaveDataList _setupService;

            public StyleWiseRejectionHandler(ISaveDataList setupService)
            {
                _setupService = setupService;
            }

            public async Task<List<StyleWiseRejectionResponseDto>> Handle(
                StyleWiseRejectionQuery request,
                CancellationToken cancellationToken)
            {
                return await _setupService.GetStyleWiseRejectionData(
                    request.UnitId,
                    request.BuyerId,
                    request.FromDate,
                    request.ToDate
                );
            }
        }
    }
