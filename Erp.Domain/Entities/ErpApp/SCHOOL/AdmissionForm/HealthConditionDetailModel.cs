using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.AdmissionForm
{
    public class HealthConditionDetailModel
    {
        public int Id { get; set; }
        public int admissionFormId { get; set; }
        public string sphConditionId { get; set; }
        public string specialHealthCondition { get; set; }
        public string IsHealthCondition { get; set; }

        public string Active_YN { get; set; }
    }
}
