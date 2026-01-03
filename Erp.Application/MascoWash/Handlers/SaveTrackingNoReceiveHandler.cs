using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class SaveTrackingNoReceiveHandler
        : IRequestHandler<SaveTrackingNoReceive, Result>
    {
        private readonly ISaveDataList _service;

        public SaveTrackingNoReceiveHandler(ISaveDataList service)
        {
            _service = service;
        }

        public async Task<Result> Handle(
    SaveTrackingNoReceive request,
    CancellationToken cancellationToken)
        {
            if (request?.Master == null)
                return Result.Failure(new[] { "Master data is required" });

            request.Master.Operation = request.Master.Operation?.ToUpper();

            //if (request.Master.Operation != "INSERT" &&
            //    request.Master.Operation != "UPDATE")
            //    return Result.Failure(new[] { "Invalid operation" });

            //if (request.Master.Operation == "UPDATE" &&
            //    (!request.Master.MasterId.HasValue || request.Master.MasterId == 0))
            //    return Result.Failure(new[] { "MasterId required for UPDATE" });

            //if (request.Details == null || !request.Details.Any())
            //    return Result.Failure(new[] { "Details are required" });

            //if (request.Details.Any(d => d.SizeDetails == null || !d.SizeDetails.Any()))
            //    return Result.Failure(new[] { "Each detail must have size details" });

            return await _service.SaveTrackingReceive(request);
        }

    }
}
