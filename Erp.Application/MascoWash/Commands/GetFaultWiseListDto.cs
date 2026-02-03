using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class GetFaultWiseListDto
    {
        public int Id { get; set; }
        public int FaultNameId { get; set; }
        public string FaultName { get; set; }
        public string Faultvalue { get; set; }
        public int FaultHeadId { get; set; }
        public string FaultHeadName { get; set; }
        public int InspectionTypeId { get; set; }
        public string InspectionTypeName  { get; set; }
        public int InspectionHeadId { get; set; }
        public string InspectionHeadName { get; set; }
        public bool IsActive { get; set; }
    }
}



