using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement.Query
{
    class GetMenusByUserIdHandler : IRequestHandler<GetMenusByUserId, List<CreateMenuPermisionObj>>
    {
        private readonly ICreateMenuPermission _createMenuPermission;

        public GetMenusByUserIdHandler(ICreateMenuPermission createMenuPermission)
        {
            _createMenuPermission = createMenuPermission;
        }
        public Task<List<CreateMenuPermisionObj>> Handle(GetMenusByUserId request, CancellationToken cancellationToken)
        {
            return _createMenuPermission.GetAllMenusByUserId(request.UserId);
        }
    }
}
