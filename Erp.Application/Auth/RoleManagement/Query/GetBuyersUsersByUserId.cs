using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class GetBuyersUsersByUserId : IRequest<List<BuyersUsersDto>>
    {
        public int UserId { get; set; }
        public GetBuyersUsersByUserId(int UserId)
        {
            this.UserId = UserId;
        }
    }
}
