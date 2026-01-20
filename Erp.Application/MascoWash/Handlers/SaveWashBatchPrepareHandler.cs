
using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    internal class SaveWashBatchPrepareHandler
        : IRequestHandler<SaveWashBatchPrepareModel, Result>
    {
        private readonly ISaveDataList _service;

        public SaveWashBatchPrepareHandler(ISaveDataList service)
        {
            _service = service;
        }

        public async Task<Result> Handle(
            SaveWashBatchPrepareModel request,
            CancellationToken cancellationToken)
        {
            if (request?.Master == null)
                return Result.Failure(new[] { "Master data is required" });

            //if (request.SizeDetails == null || request.SizeDetails.Count == 0)
            //    return Result.Failure(new[] { "Size details are required" });

            request.Master.operation =
                request.Master.operation?.ToUpper() ?? "INSERT";

            request.Master.createdBy ??= "SYSTEM";

            return await _service.SaveWashBatchPrepareData(request);
        }
    }
}
