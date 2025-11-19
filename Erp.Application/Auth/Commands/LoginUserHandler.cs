using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Common.Interfaces;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using MediatR;

namespace Erp.Application.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginUser, List<UserCreateDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        //public async Task<object> Handle(LoginUser request, CancellationToken cancellationToken)
        //{
        //    var user = _mapper.Map<UserForLoginDto>(request);

        //    return await _identityService.Login(user);
        //}

        public async Task<List<UserCreateDto>> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserForLoginDto>(request);

            return await _identityService.LoginNew(user);
        }

    }
}
