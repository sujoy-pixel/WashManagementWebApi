using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.Commands
{
    public class SetUserDevice : IRequest<Result>
    {
        public string UserName { get; set; }
        public string DeviceId { get; set; }
    }
}
