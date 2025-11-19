using System.Security.Claims;
using System.Threading.Tasks;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Common.Interfaces;
using Erp.Infrastructure.Identity;
using Erp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Erp.Infrastructure.Filter
{
    public class AuthorizationFilter : IAsyncActionFilter
    {
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;
        //private readonly ICreateMenuPermission _createMenuPermission;
        public AuthorizationFilter(UserManager<User> userManager, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            //_createMenuPermission = createMenuPermission;

        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var action = context.RouteData.Values["action"].ToString();

            if (string.IsNullOrEmpty(action) || context.Controller.GetType().GetMethod(action).GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Length <= 0)
            {
                var controller = context.RouteData.Values["controller"].ToString();
                string userRole = controller + "_" + action;
                //var userName = context.HttpContext.User.Identity.Name;
                //var user = await _userManager.FindByNameAsync(userName);
                //var ck = await _userManager.IsInRoleAsync(user, userRole);
                //var actionList = await _createMenuPermission.GetCurrentActionsByUserId(_currentUserService.UserId, userRole);

                //if (!context.HttpContext.User.IsInRole(userRole) && !context.HttpContext.User.IsInRole("Admin"))
                //{
                //    context.Result = new UnauthorizedResult();
                //    return;
                //}

                //if (actionList.Count == 0)
                //{
                //    context.Result = new UnauthorizedResult();
                //    return;
                //}

            }

            var resultContext = await next();
        }
    }
}
