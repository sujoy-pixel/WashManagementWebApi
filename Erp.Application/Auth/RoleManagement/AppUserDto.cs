using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
    }
}
