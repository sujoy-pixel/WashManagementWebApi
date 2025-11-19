using Erp.Application.Auth.RoleManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.SCHOOL.User.Query
{
    public class NewMenuCreateList : IRequest<List<CreateMenuPermisionDto>>
    {
        public int Id { get; set; }
    }
}
