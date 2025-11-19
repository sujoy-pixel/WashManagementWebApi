using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Requests.ErpApp.External_API_Factory.Query
{
    public class GetEmployeeInfoByUnit : IRequest<List<APIEmployeeInfoDto>>
    {
        public string Unit { get; set; }

    }
}
