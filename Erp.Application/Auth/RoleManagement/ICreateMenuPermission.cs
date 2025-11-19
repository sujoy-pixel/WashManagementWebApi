
using Erp.Application.Auth.RoleManagement.Command;
using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using Erp.Domain.Entities.MenuPermission;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Erp.Domain.Entities.MenuPermission.SecurityMenuPermisionModel;

namespace Erp.Application.Auth.RoleManagement
{
    public interface ICreateMenuPermission
    {
        //Task<Result> CreateMenuPermission(CreateMenuPermission objSecurityMenuPermisionModel);
        //Task<Result> SeedMenuMenus(int userId);
        //Task<Result> MenuPermissionByUserId(CreateMenuPermissionByUserId model);
        //Task<Result> MenuActionPermissionByUserId(AppUserDataPermissionDto model);
        //Task<List<CreateMenuPermisionDto>> GetAllMenu();
        Task<List<CreateMenuPermisionObj>> GetAllMenusByUserId(int UserId);
        //Task<List<CreateMenuPermisionDto>> GetAllMenusByUserId();
        //Task<List<AppUserDataPermissionDto>> GetCurrentActionsByUserId(int userId, string actionName);
        Task<Result> CreateUserList(UserRollDto UserRollDto);
    }
}
