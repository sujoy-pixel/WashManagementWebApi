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
    public class saveInspectionHeadDataHandler : IRequestHandler<saveInspectionHeadData, WrapperResponseInspectionHead>
    {
        private readonly ISaveDataList _setupservice;
        public saveInspectionHeadDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public async Task<WrapperResponseInspectionHead> Handle(saveInspectionHeadData request, CancellationToken cancellationToken)
        {


            saveInspectionHeadData obj = new saveInspectionHeadData
            {
                Operation = request.Operation,
                InspectionHeadId = request.InspectionHeadId,
                HeadName = request.HeadName,
                Priority = request.Priority,
                IsActive = request.IsActive
            };

            WrapperResponseInspectionHead response = await _setupservice.saveInspectionHeadData(obj);
            return response;
        }

    }
}
