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
    public class SaveFaultWiseValueDataHandler
    : IRequestHandler<SaveFaultWiseValueModel, Result>
    {
        private readonly ISaveDataList _setupService;

        public SaveFaultWiseValueDataHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<Result> Handle(
            SaveFaultWiseValueModel request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Null request check
            if (request == null)
            {
                return Result.Failure(new[] { "Request data is null" });
            }

            // 6️⃣ Call service
            return await _setupService.SaveFaultWiseValueData(request);
        }
    }



}


