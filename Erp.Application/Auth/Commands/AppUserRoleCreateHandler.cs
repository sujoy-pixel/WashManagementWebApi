using AutoMapper;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.Commands
{
    public class AppUserRoleCreateHandler : IRequestHandler<AppUserRoleCreate, Result>
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AppUserRoleCreateHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(AppUserRoleCreate request, CancellationToken cancellationToken)
        {
            var result = Result.Success();
            foreach (var item in request.UserRoleList)
            {
                UserRoleDto userRoleDto = new UserRoleDto
                {
                    UserId = request.UserId,
                    RoleId = item.RoleId
                };
                result = await _appUserService.CreateUserRole(userRoleDto);

            }
            return result;
        }
    }
}
