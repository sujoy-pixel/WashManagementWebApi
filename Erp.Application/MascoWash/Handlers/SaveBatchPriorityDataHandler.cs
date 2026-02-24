
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class SaveBatchPriorityDataHandler
        : IRequestHandler<SaveBatchPriorityModel, WrapperResponseBatchPriority>
    {
        private readonly ISaveDataList _setupservice;

        public SaveBatchPriorityDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public async Task<WrapperResponseBatchPriority> Handle(
            SaveBatchPriorityModel request,
            CancellationToken cancellationToken)
        {
            // directly pass to repository/service
            var response = await _setupservice.SaveBatchPriorityBulk(request);
            return response;
        }
    }
}
