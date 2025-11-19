using Erp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement
{
    public interface IAppUserService
    {
        Task<List<AppUserDto>> GetAllUserList();
        Task<List<AppUserDataPermissionDto>> GetAllUserDataPermissionList();
        Task<List<AppUserDataPermissionDto>> GetAllUserDataPermissionById(int id);
        Task<Result> CreateUserRole(UserRoleDto userRoleDto);
    }
}
