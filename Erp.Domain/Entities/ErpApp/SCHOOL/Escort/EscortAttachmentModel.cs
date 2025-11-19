using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.Escort
{
    public class EscortAttachmentModel : AuditableEntity
    {
        public string BearerName { get; set; }
        public int sRelationshipId { get; set; }
        public string RelationshipTypeNAME { get; set; }
        public string SpecFile { get; set; }
        public string EscortFormMasterId { get; set; }
        public string EscortFormId { get; set; }
        public int FileObjectId { get; set; }
        public string File_Name { get; set; }
    }
}
