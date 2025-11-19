using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class AppUserHandler : IRequestHandler<AppUser, List<AppUserDto>>
    {
        private readonly IAppUserService _appUser;
        public AppUserHandler(IAppUserService appUser)
        {
            _appUser = appUser;
        }
        public Task<List<AppUserDto>> Handle(AppUser request, CancellationToken cancellationToken)
        {
            var res = _appUser.GetAllUserList();
            return res;
        }
    }
}
