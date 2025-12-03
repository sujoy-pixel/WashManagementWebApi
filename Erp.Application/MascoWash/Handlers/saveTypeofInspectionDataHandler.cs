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
    public class saveTypeofInspectionDataHandler : IRequestHandler<saveTypeofInspectionData, WrapperResponseTypeofInspection>
    {
        private readonly ISaveDataList _setupservice;
        public saveTypeofInspectionDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public async Task<WrapperResponseTypeofInspection> Handle(saveTypeofInspectionData request, CancellationToken cancellationToken)
        {


            saveTypeofInspectionData obj = new saveTypeofInspectionData
            {
                Operation = request.Operation,
                TypeofInspectionId = request.TypeofInspectionId,
                TypeName = request.TypeName,
                Priority = request.Priority,
                IsActive = request.IsActive
            };

            WrapperResponseTypeofInspection response = await _setupservice.saveTypeofInspectionData(obj);
            return response;
        }

    }
}
