
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class saveProcessNameDataHandler : IRequestHandler<saveProcessNameData, WrapperResponseProcessName>
    {
        private readonly ISaveDataList _setupservice;
        public saveProcessNameDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public async Task<WrapperResponseProcessName> Handle(saveProcessNameData request, CancellationToken cancellationToken)
        {


            saveProcessNameData obj = new saveProcessNameData
            {
                Operation = request.Operation,
                OperationId=request.OperationId,
                ProcessId = request.ProcessId,
                UnitId = request.UnitId,
                ProcessName = request.ProcessName,
                Priority=request.Priority,  
                IsActive = request.IsActive
            };

            WrapperResponseProcessName response = await _setupservice.saveProcessNameEntryData(obj);
            return response;
        }

    }
}
