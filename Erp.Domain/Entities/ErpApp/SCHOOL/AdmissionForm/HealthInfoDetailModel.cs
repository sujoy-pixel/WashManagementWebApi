using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.AdmissionForm
{
    public class HealthInfoDetailModel
    {
        public int Id { get; set; }
        public int admissionFormId { get; set; }
        public string diseaseNameId { get; set; }
        public string diseaseName { get; set; }
        public string IsdiseasCondition { get; set; }
        public DateTime? diseasDate { get; set; }
        public string Active_YN { get; set; }
    }
}
