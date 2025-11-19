using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class AppUserDataPermissionById : IRequest<List<AppUserDataPermissionDto>>
    {
        public int Id { get; set; }
        public AppUserDataPermissionById(int Id)
        {
            this.Id = Id;
        }
    }
    public class AppUserDataPermissionByIdHandler : IRequestHandler<AppUserDataPermissionById, List<AppUserDataPermissionDto>>
    {
        private readonly IAppUserService _appUserService;
        public AppUserDataPermissionByIdHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public Task<List<AppUserDataPermissionDto>> Handle(AppUserDataPermissionById request, CancellationToken cancellationToken)
        {
            var res = _appUserService.GetAllUserDataPermissionById(request.Id);
            return res;
        }
    }
}
