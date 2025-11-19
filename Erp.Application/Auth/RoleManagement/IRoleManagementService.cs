using Erp.Application.Auth.RoleManagement.Command;
using Erp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement
{
    public interface IRoleManagementService
    {
        Task<Result> CreateRole(int id,string roleName);
        Task<List<RoleDto>> GetAllRole();
       

    }
}
