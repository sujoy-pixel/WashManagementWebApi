using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.Escort
{
    public class EscortFormModel
    {
        public int EscortId { get; set; }
        public int SchoolId { get; set; }
        public int BranchId { get; set; }
        public int StudentId { get; set; }
        public string NameData { get; set; }
        public string SectionData { get; set; }
        public string GradeData { get; set; }
        public string ShiftData { get; set; }
    }
}
