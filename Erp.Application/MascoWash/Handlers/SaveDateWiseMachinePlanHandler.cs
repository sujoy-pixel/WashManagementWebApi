using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class SaveDateWiseMachinePlanHandler
        : IRequestHandler<SaveDateWiseMachinePlanCommand, Result>
    {
        private readonly ISaveDataList _service;
        public SaveDateWiseMachinePlanHandler(ISaveDataList service) => _service = service;

        public async Task<Result> Handle(SaveDateWiseMachinePlanCommand request, CancellationToken cancellationToken)
        {
            if (request?.PlanData == null || request.PlanData.Count == 0)
                return Result.Failure(new[] { "No plan lines to save" });

            return await _service.SaveWashDateWiseMachinePlan(request);
        }
    }
}
