using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using MediatR;

namespace Erp.Application.Auth.Commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, Result>
    {

        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;

        }

        public async Task<Result> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var result = await _identityService.DeleteUser(request.Id);
            return result;
        }
    }
}
