using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Erp.Infrastructure.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public string AddressFirst { get; set; }
        public string AddressSecond { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Post { get; set; }
        public string Gender { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Deleted { get; set; }
        public int HeadOfficeId { get; set; }
        public int BranchOfficeId { get; set; }
        [NotMapped]
        public int FinYearId { get; set; }
        public string TokenNumber { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
