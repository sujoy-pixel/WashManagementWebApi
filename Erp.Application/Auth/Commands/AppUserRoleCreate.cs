using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.Commands
{
    public class AppUserRoleCreate : IRequest<Result>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public List<AppUserRoleCreate> UserRoleList { get; set; }
    }
}
