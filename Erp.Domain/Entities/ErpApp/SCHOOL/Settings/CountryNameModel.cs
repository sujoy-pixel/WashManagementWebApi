using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.Settings
{
    public class CountryNameModel : AuditableEntity
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public string ActiveStatus { get; set; }
    }
}
