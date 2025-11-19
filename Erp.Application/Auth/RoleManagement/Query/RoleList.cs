using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class RoleList : IRequest<List<RoleDto>>
    {
    }
}
