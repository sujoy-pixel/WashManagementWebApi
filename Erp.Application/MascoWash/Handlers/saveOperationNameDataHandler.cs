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
    public class saveOperationNameDataHandler : IRequestHandler<saveOperationNameData, WrapperResponseOperationName>
    {
        private readonly ISaveDataList _setupservice;
        public saveOperationNameDataHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }
        public async Task<WrapperResponseOperationName> Handle(saveOperationNameData request, CancellationToken cancellationToken)
        {


            saveOperationNameData obj = new saveOperationNameData
            {
                Operation = request.Operation,
                OperationId = request.OperationId,
                OperationName = request.OperationName,
                Priority = request.Priority,
                IsActive = request.IsActive
            };

            WrapperResponseOperationName response = await _setupservice.saveOperationNameEntryData(obj);
            return response;
        }

    }
}
