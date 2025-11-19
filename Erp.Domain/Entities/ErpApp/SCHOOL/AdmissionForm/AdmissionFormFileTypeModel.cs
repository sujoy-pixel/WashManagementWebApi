using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.AdmissionForm
{
    public class AdmissionFormFileTypeModel : AuditableEntity
    {            
        public string AdmissionFormMasterId { get; set; }
        public string admissionFormId { get; set; }
        public string FilE_TYPE_ID { get; set; }
        public int FileObjectId { get; set; }       
        public string studentBasicInfoFileType_filE_TYPE_NAME { get; set; }
        public string FilE_NAME { get; set; }
        public string studentBasicInfoSpecFile { get; set; }       
    }
}
