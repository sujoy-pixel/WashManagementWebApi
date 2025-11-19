using Dapper;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Auth.RoleManagement.Command;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using Erp.Domain.Entities.MenuPermission;
using Erp.Infrastructure.Persistence;
 
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Erp.Domain.Entities.MenuPermission.SecurityMenuPermisionModel;

namespace Erp.Infrastructure.Auth.RoleManagement
{
    public class SetupService : DbContext<CreateMenuPermission>, ICreateMenuPermission
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISetupService _setupService;

        public SetupService(ICurrentUserService currentUserService, IConfiguration configuration, ApplicationDbContext dbcontext) : base(configuration)
        {
            _dbContext = dbcontext;
            _currentUserService = currentUserService;
      
        }

        //public async Task<List<CreateMenuPermisionObj>> GetAllMenusByUserId(int UserId)
        //{

        //    List<CreateMenuPermisionObj> list = new List<CreateMenuPermisionObj>();
        //    DynamicParameters parameter = new DynamicParameters();
        //    string query = "usp_Load_Dynamic_Menu";
        //    parameter.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);

        //    var GetMenuList = await GetDisposeErrorFreeListAsyncNew<CreateMenuPermisionObj>(query, parameter);
        //    foreach (var item in GetMenuList)
        //    {
        //        var obj = new CreateMenuPermisionObj
        //        {
        //            Menu_Id = item.Menu_Id,
        //            Menu_Name = item.Menu_Name,
        //            Parent_Menu_Id = item.Parent_Menu_Id,
        //            Is_Active = item.Is_Active,
        //            Step_No = item.Step_No,
        //            Page_link = item.Page_link,
        //            Remarks = item.Remarks,
        //            Icon = item.Icon,
        //            Type = item.Type,
        //            IsSelected = true,
        //            UserId = item.UserId
        //        };
        //        list.Add(obj);

        //    }

        //    return list;

        //}
        public async Task<List<CreateMenuPermisionObj>> GetAllMenusByUserId(int UserId)
        {
            DynamicParameters parameter = new DynamicParameters();
            string query = "usp_Load_Dynamic_Menu";
            parameter.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);

            // Get flat menu list from DB
            var flatMenuList = await GetDisposeErrorFreeListAsyncNew<CreateMenuPermisionObj>(query, parameter);

            // Ensure IsSelected = true for all
            foreach (var item in flatMenuList)
            {
                item.IsSelected = true;
                item.Children = new List<CreateMenuPermisionObj>(); // initialize children
            }

            // Dictionary for quick lookup
            var lookup = flatMenuList.ToDictionary(m => m.Menu_Id);

            // Build parent-child relationships
            foreach (var menu in flatMenuList)
            {
                if (menu.Parent_Menu_Id != 0 && lookup.ContainsKey(menu.Parent_Menu_Id))
                {
                    lookup[menu.Parent_Menu_Id].Children.Add(menu);
                }
            }

            // Return only top-level menus (Parent_Menu_Id = 0)
            return flatMenuList.ToList();
        }



        public async Task<Result> CreateUserList(UserRollDto UserRollDto)
        {

            List<CreateMenuPermisionObj> list = new List<CreateMenuPermisionObj>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "usp_Load_Dynamic_Menu";
            parameter.Add("UserId", UserRollDto.School_Name_Id, DbType.Int32, ParameterDirection.Input);

            var GetMenuList = await GetDisposeErrorFreeListAsyncNew<CreateMenuPermisionObj>(query, parameter);
            foreach (var item in GetMenuList)
            {
                var obj = new CreateMenuPermisionObj
                {
                    Menu_Id = item.Menu_Id,
                    Menu_Name = item.Menu_Name,
                    Parent_Menu_Id = item.Parent_Menu_Id,
                    Is_Active = item.Is_Active,
                    Step_No = item.Step_No,
                    Page_link = item.Page_link,
                    Remarks = item.Remarks,
                    Icon = item.Icon,
                    Type = item.Type,
                    IsSelected = true,
                    UserId = item.UserId
                };
                list.Add(obj);

            }

            return Result.Success();

        }

    }
}
