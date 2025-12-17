using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
   
    
    public class CheckMachineExistsDto
    {
        public int UnitId { get; set; }
        public int OperationId { get; set; }
        public string MachineName { get; set; }
    }

}
