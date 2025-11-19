using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.Commands
{
    public class ResetPasswordForAdmin : IRequest<Result>
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
    }
}
