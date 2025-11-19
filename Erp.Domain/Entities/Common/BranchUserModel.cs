using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Domain.Entities.Common
{
    public class BranchUserModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BranchOfficeId { get; set; }
        public string Remarks { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDefault { get; set; }
    }
}
