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
    public class saveInspectionAreaDataHandler : IRequestHandler<saveInspectionAreaData, WrapperResponseInspectionArea>
    {
        private readonly ISaveDataList _setupservice;
        public saveInspectionAreaDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public async Task<WrapperResponseInspectionArea> Handle(saveInspectionAreaData request, CancellationToken cancellationToken)
        {


            saveInspectionAreaData obj = new saveInspectionAreaData
            {
                Operation = request.Operation,
                InspectionAreaId = request.InspectionAreaId,
                InspectionArea = request.InspectionArea,
                Priority = request.Priority,
                IsActive = request.IsActive
            };

            WrapperResponseInspectionArea response = await _setupservice.saveInspectionAreaData(obj);
            return response;
        }

    }
}
