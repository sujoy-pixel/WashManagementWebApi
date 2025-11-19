using Erp.Application.Auth.RoleManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.SCHOOL.User.Query
{
    public class GetMenusByUserId : IRequest<List<CreateMenuPermisionDto>>
    {
        //public int UserId { get; set; }
        //public GetMenusByUserId()
        //{
        //   // this.UserId = UserId;

        //}
        public int Id { get; set; }
        public int Id1 { get; set; }
        public int Id2 { get; set; }
    }
}
