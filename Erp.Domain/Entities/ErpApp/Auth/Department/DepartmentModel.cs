using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Erp.Domain.Entities.ErpApp.Auth.Department
{
    [Table("L_ROL_DEPARTMENT")]
    public class DepartmentModel : AuditableEntity
    {
            public int ID { get; set; }
            public string Department_Name { get; set; } 

        }
}
