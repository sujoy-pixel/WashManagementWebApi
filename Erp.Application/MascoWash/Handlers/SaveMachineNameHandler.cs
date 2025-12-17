using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class SaveMachineNameHandler
    : IRequestHandler<SaveMachineName, Result>
    {
        private readonly ISaveDataList _setupService;

        public SaveMachineNameHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<Result> Handle(
            SaveMachineName request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Null request check
            if (request == null)
            {
                return Result.Failure(new[] { "Request data is null" });
            }

            // 2️⃣ Operation validation
            if (string.IsNullOrWhiteSpace(request.Operation))
            {
                return Result.Failure(new[] { "Operation is required" });
            }

            // 3️⃣ MasterId validation for UPDATE / DELETE
            if ((request.Operation == "UPDATE" || request.Operation == "DELETE")
                && (!request.MasterId.HasValue || request.MasterId == 0))
            {
                return Result.Failure(new[] { "MasterId is required for update or delete" });
            }

            // 4️⃣ Detail list validation ONLY for INSERT / UPDATE
            if ((request.Operation == "INSERT" || request.Operation == "UPDATE")
                && (request._listData == null || !request._listData.Any()))
            {
                return Result.Failure(new[] { "Machine detail list is empty" });
            }

            // 5️⃣ DELETE → ensure empty list (safe guard)
            if (request.Operation == "DELETE")
            {
                request._listData ??= new List<machineDetailModel>();
            }

            // 6️⃣ Call service
            return await _setupService.saveMachineName(request);
        }
    }

    //public class SaveMachineNameHandler
    //: IRequestHandler<SaveMachineName, Result>
    //{
    //    private readonly ISaveDataList _setupService;

    //    public SaveMachineNameHandler(ISaveDataList setupService)
    //    {
    //        _setupService = setupService;
    //    }

    //    public async Task<Result> Handle(
    //        SaveMachineName request,
    //        CancellationToken cancellationToken)
    //    {
    //        if (request == null)
    //        {
    //            return Result.Failure(new[] { "Request data is null" });
    //        }

    //        if (request._listData == null || !request._listData.Any())
    //        {
    //            return Result.Failure(new[] { "Machine detail list is empty" });
    //        }

    //        return await _setupService.saveMachineName(request);
    //    }
    //}


}


