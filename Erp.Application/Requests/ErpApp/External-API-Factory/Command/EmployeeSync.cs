using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Requests.ErpApp.External_API_Factory.Command
{
    public class EmployeeSync : IRequest<Result>
    {
    }

    public class TaxableEmployeeSync : IRequest<Result>
    {
    }
}
