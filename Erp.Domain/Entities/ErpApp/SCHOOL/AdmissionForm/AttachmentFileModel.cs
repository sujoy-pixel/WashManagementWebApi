using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.AdmissionForm
{
    public class AttachmentFileModel
    {
      
        public int Id { get; set; }
        public int admissionFormId { get; set; }
        public int filE_TYPE_ID { get; set; }
        public string studentBasicInfoFileType_filE_TYPE_NAME { get; set; }
        public string studentBasicInfoSpecFile { get; set; }
        public int FileObjectId { get; set; }
        public int RefId { get; set; }
        //public string FormFile { get; set; }
        public string Owner { get; set; }
        public string FileComment { get; set; }
        public string FileName { get; set; }
      
        public string FileRevised { get; set; }
        public string Active_YN { get; set; }
        public long FileSize { get; set; }
        public int Version { get; set; }
        public string FileType { get; set; }
        public string Location { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocTitle { get; set; }
        public List<IFormFile> FormFile { get; set; }
        //public List<studentInfoAttachmentDetailDto> studentInfoAttachmentData { get; set; }

    }
}
