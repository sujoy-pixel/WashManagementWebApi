using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class GetMenusByUserId : IRequest<List<CreateMenuPermisionObj>>
    {
        public int UserId { get; set; }
        public GetMenusByUserId(int UserId)
        {
            this.UserId = UserId;

        }
    }
}
