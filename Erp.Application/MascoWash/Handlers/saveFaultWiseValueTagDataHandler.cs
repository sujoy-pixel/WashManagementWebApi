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
    public class saveFaultWiseValueTagDataHandler: IRequestHandler<saveFaultWiseValueTagData, WrapperResponseFaultWiseValueTag>
    {
        private readonly ISaveDataList _setupservice;

        public saveFaultWiseValueTagDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public async Task<WrapperResponseFaultWiseValueTag> Handle(saveFaultWiseValueTagData request,CancellationToken cancellationToken)
        {
            saveFaultWiseValueTagData obj = new saveFaultWiseValueTagData
            {
                Operation = request.Operation,
                FaultWiseMasterId = request.FaultWiseMasterId,
                Type = request.Type,
                InspectionHeadId = request.InspectionHeadId,
                FaultHeadId = request.FaultHeadId,
                CreatedBy = request.CreatedBy,
                FaultWiseDetails = request.FaultWiseDetails
            };

            WrapperResponseFaultWiseValueTag response =
                await _setupservice.saveFaultWiseValueTagData(obj);

            return response;
        }
    }

}
