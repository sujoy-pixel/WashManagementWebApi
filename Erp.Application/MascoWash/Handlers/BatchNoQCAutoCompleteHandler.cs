using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;

namespace Erp.Application.MascoWash.Handlers
{
    public class BatchNoQCAutoCompleteHandler
     : IRequestHandler<BatchNoQCAutoCompleteQuery, List<BatchNoQCAutoCompleteDto>>
    {
        private readonly ISaveDataList _setupService;

        public BatchNoQCAutoCompleteHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<List<BatchNoQCAutoCompleteDto>> Handle(
            BatchNoQCAutoCompleteQuery request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetBatchNoQCAutoComplete(request.SearchText);
        }
    }
}