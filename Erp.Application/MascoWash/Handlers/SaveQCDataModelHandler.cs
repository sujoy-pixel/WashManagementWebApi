using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//namespace Erp.Application.MascoWash.Handlers
//{
//    public class SaveQCDataModelHandler: IRequestHandler<SaveQCDataModel, WrapperResponseQCData>
//    {
//        private readonly ISaveDataList _setupservice;

//        public SaveQCDataModelHandler(ISaveDataList setupservice)
//        {
//            _setupservice = setupservice;
//        }

//        public async Task<WrapperResponseBatchPriority> Handle(
//            SaveQCDataModel request,
//            CancellationToken cancellationToken)
//        {
//            // directly pass to repository/service
//            var response = await _setupservice.SaveQcData(request);
//            return response;
//        }
//    }
//}
// ── Handler ──────────────────────────────────
public class SaveQCDataModelHandler
    : IRequestHandler<SaveQCDataModel, WrapperResponseQCData>
{
    private readonly ISaveDataList _setupservice;

    public SaveQCDataModelHandler(ISaveDataList setupservice)
    {
        _setupservice = setupservice;
    }
   
    public async Task<WrapperResponseQCData> Handle(
        SaveQCDataModel request,
        CancellationToken cancellationToken)
    {
        var response = await _setupservice.SaveQcData(request);
        return response;
    }
}