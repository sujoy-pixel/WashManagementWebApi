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
    public class saveFaultHeadDataHandler : IRequestHandler<saveFaultHeadData, WrapperResponseFaultHead>
    {
        private readonly ISaveDataList _setupservice;
        public saveFaultHeadDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public async Task<WrapperResponseFaultHead> Handle(saveFaultHeadData request, CancellationToken cancellationToken)
        {


            saveFaultHeadData obj = new saveFaultHeadData
            {
                Operation = request.Operation,
                FaultHeadId = request.FaultHeadId,
                CodeNo = request.CodeNo,
                FaultHeadName = request.FaultHeadName,
                Priority = request.Priority,
                IsActive = request.IsActive
            };

            WrapperResponseFaultHead response = await _setupservice.saveFaultHeadData(obj);
            return response;
        }

    }
}
