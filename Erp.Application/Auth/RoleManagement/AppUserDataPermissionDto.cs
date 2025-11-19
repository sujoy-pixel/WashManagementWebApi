using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement
{
    public class AppUserDataPermissionDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ActionSetupId { get; set; }
        public string ActionName { get; set; }
        public string ActionUrlName { get; set; }
        public bool IsSelected { get; set; }
        public int ActionId { get; set; }
        public int Id { get; set; }

    }
}


