using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.Commands
{
    public class SIgnInFromSara : IRequest<object>
    {
        public string EmployeeId { get; set; }
    }
}
