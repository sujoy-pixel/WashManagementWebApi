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
    public class saveFaultNameDataHandler : IRequestHandler<saveFaultNameData, WrapperResponseFaultName>
    {
        private readonly ISaveDataList _setupservice;
        public saveFaultNameDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public async Task<WrapperResponseFaultName> Handle(saveFaultNameData request, CancellationToken cancellationToken)
        {


            saveFaultNameData obj = new saveFaultNameData
            {
                Operation = request.Operation,
                FaultNameId = request.FaultNameId,
                FaultName = request.FaultName,
                FaultHeadId = request.FaultHeadId,
                CodeNo = request.CodeNo,
                Priority = request.Priority,
                IsActive = request.IsActive
            };

            WrapperResponseFaultName response = await _setupservice.saveFaultNameData(obj);
            return response;
        }

    }
}
