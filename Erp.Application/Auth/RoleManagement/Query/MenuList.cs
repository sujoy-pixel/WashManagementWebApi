using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class MenuList : IRequest<List<CreateMenuPermisionDto>>
    {
    }

}
