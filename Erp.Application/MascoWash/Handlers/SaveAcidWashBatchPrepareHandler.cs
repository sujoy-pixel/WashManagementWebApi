// SaveAcidWashBatchPrepareHandler.cs
using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    internal class SaveAcidWashBatchPrepareHandler
        : IRequestHandler<SaveAcidWashBatchPrepareCommand, Result>
    {
        private readonly ISaveDataList _service;

        public SaveAcidWashBatchPrepareHandler(ISaveDataList service)
        {
            _service = service;
        }

        public async Task<Result> Handle(
            SaveAcidWashBatchPrepareCommand request,
            CancellationToken cancellationToken)
        {
            if (request?.Master == null)
                return Result.Failure(new[] { "Master data is required" });

            if (string.IsNullOrWhiteSpace(request.Master.BatchNo))
                return Result.Failure(new[] { "Wash Batch No is required" });

            if (string.IsNullOrWhiteSpace(request.Master.ProcessIds))
                return Result.Failure(new[] { "Process selection is required" });

            if (string.IsNullOrWhiteSpace(request.Master.MachineIds))
                return Result.Failure(new[] { "Machine selection is required" });

            if (request.Master.TotalPcs <= 0)
                return Result.Failure(new[] { "Total Pcs must be greater than 0" });

            request.Master.Operation =
                request.Master.Operation?.ToUpper() ?? "INSERT";

            return await _service.SaveAcidWashBatchPrepareData(request);
        }
    }
}