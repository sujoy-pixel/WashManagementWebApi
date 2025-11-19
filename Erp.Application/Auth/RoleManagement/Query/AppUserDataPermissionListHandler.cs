using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class AppUserDataPermissionListHandler : IRequestHandler<AppUserDataPermissionList, List<AppUserDataPermissionDto>>
    {
        private readonly IAppUserService _appUser;
        public AppUserDataPermissionListHandler(IAppUserService appUser)
        {
            _appUser = appUser;
        }
        public Task<List<AppUserDataPermissionDto>> Handle(AppUserDataPermissionList request, CancellationToken cancellationToken)
        {
            var res = _appUser.GetAllUserDataPermissionList();
            return res;
        }
    }
}
