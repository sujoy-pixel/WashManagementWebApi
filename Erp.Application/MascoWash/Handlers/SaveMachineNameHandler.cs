using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Common.Models;
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
    
    public class SaveMachineNameHandler : IRequestHandler<SaveMachineName, List<machineDetailModel>>
    {
        private readonly ISaveDataList _setupservice;
        public SaveMachineNameHandler(ISaveDataList setupservice)
        {
            _setupservice = setupservice;
        }

        public async Task<List<machineDetailModel>> Handle(SaveMachineName request, CancellationToken cancellationToken)
        {
            var result = Result.Success();
            SaveMachineName objmaster = new SaveMachineName();
            List<machineDetailModel> objDetailList = new List<machineDetailModel>();

            objmaster.UnitId = request.UnitId;
            objmaster.OperationId = request.OperationId;

            foreach (var item in request._listData)
            {
                machineDetailModel detail = new machineDetailModel();
                detail.MachineDetailId = item.MachineDetailId;
                detail.MachineName = item.MachineName;
                detail.IsActive = item.IsActive;
                objDetailList.Add(detail);
                objmaster._listData = objDetailList;
            }
            objDetailList = await _setupservice.SaveMachineName(objmaster);
            return objDetailList;
        }
    }
}
