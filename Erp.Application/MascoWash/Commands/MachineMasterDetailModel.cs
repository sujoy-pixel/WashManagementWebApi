using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Commands
{
    public class MachineMasterDetailModel
    {
        public int MachineNameMasterId { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public int MachineDetailId { get; set; }
        public string MachineName { get; set; }
        public bool IsActive { get; set; }
    }

}
