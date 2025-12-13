using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Commands
{
    
    public class SaveMachineName : IRequest<List<machineDetailModel>>
    {
        public string Operation { get; set; }
        public int UnitId { get; set; }
        public int OperationId { get; set; }
        public string CreatedBy { get; set; }

        // Table Valued Parameter List
        public List<machineDetailModel> _listData { get; set; }

    }


    public class wrapperSaveObj
    {
        public List<machineDetailModel> saveList { get; set; }
    }
    public class machineDetailModel
    {
        public int MachineDetailId { get; set; }
        public int MachineNameMasterId { get; set; }
        public string MachineName { get; set; }
        public bool IsActive { get; set; }
    }
}
