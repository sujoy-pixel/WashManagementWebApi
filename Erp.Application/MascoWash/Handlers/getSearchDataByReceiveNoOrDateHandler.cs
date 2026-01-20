using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Handlers
{
    public class getSearchDataByReceiveNoOrDateHandler
          : IRequestHandler<GetDataBySearchForEdit, List<TrackingNoWiseReceiveDto>>
    {
        private readonly ISaveDataList _setupService;
        public getSearchDataByReceiveNoOrDateHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }
        public async Task<List<TrackingNoWiseReceiveDto>> Handle(
            GetDataBySearchForEdit request,
            CancellationToken cancellationToken)
        {
            return await _setupService.GetDataBySearchForEditService(request.UnitId,request.ReceiveNo,request.FromDate,request.ToDate);

        }
    }
}




