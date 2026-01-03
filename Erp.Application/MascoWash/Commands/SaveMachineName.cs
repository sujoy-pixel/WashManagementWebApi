using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Commands
{

    public class SaveMachineName : IRequest<Result>
    {
        public string Operation { get; set; }
        public int UnitId { get; set; }
        public int OperationId { get; set; }
        public int? MasterId { get; set; }   // nullable (INSERT safe)
        public string CreatedBy { get; set; }

        public List<machineDetailModel> _listData { get; set; } = new();
    }

    public class machineDetailModel
    {
        public int MachineDetailId { get; set; }
        public int MachineNameMasterId { get; set; }
        public string MachineName { get; set; }
        public bool IsActive { get; set; }
    }

    
}
