using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public List<UserRoleDto> UserRoleList { get; set; }
    }
}
