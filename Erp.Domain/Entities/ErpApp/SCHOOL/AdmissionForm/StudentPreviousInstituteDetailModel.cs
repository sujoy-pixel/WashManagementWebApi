using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.AdmissionForm
{
    public class StudentPreviousInstituteDetailModel
    {
        public int Id { get; set; }
        public int admissionFormId { get; set; }
        public string schoolName { get; set; }
        public string grade { get; set; }
        public string location { get; set; }
        public string result { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        //public string Active_YN { get; set; }
    }
}
