using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class GetMenuPermissionDynamically : IRequest<List<CreateMenuPermisionDto>>
    {
    }
}
