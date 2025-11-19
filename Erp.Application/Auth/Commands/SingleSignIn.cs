using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.Commands
{
    public class SingleSignIn : IRequest<object>
    {
        public string Token { get; set; }
    }
}
