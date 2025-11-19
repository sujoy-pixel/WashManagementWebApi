using Erp.Application.Auth.RoleManagement;
using Erp.Application.Common.Models;
using Erp.Infrastructure.Identity;
using Erp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Auth.RoleManagement
{
    public class RoleManagementService : IRoleManagementService
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleManagementService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Result> CreateRole(int id, string roleName)
        {

            if (!string.IsNullOrEmpty(roleName))
            {
                var role = new Role
                {
                    Name = roleName
                };
                
                if (id == 0)
                {
                    var roleExist =_roleManager.FindByNameAsync(roleName);
                    if (roleExist.Result != null)
                        throw new Exception("Role already exist");
                    await _roleManager.CreateAsync(role);
                }
                else
                {
                    var roleData = _roleManager.FindByIdAsync(id.ToString());
                    roleData.Result.Name = roleName;
                    await _roleManager.UpdateAsync(roleData.Result);
                    return Result.Success("Role Updated");
                }
                return Result.Success("Role Saved");
            }
            return Result.Failure(new List<string> { "Role did not saved" });
        }

        public async Task<List<RoleDto>> GetAllRole()
        {

            var roles =await _roleManager.Roles.Select(x => new RoleDto
            {
                Id=x.Id,
                RoleName=x.Name
            }).ToListAsync();
           return roles;
        }

    }
}
