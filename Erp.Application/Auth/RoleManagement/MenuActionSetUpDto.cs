using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement
{
    public class MenuActionSetUpDto
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string ActionName { get; set; }
        public string Remarks { get; set; }
    }
}
