using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.Settings
{
    public class SchoolNameModel : AuditableEntity
    {
        public int SchoolId { get; set; }
        public string SchoolNameEnglish { get; set; }
        public string SchoolNameBangla { get; set; }
        public string WebsiteName { get; set; }
    
        public string ActiveStatus { get; set; }

    }
}
