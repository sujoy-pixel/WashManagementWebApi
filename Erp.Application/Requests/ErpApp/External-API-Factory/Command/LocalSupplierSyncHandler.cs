using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.External_API_Factory.Command
{
    public class LocalSupplierSyncHandler : IRequestHandler<LocalSupplierSync, Result>
    {
        private readonly IEmployeeFromAPI _employeeFromAPI;
        public LocalSupplierSyncHandler(IEmployeeFromAPI employeeFromAPI)
        {
            _employeeFromAPI = employeeFromAPI;
        }
        public async Task<Result> Handle(LocalSupplierSync request, CancellationToken cancellationToken)
        {
            return await _employeeFromAPI.LocalSupplierSync();
        }
    }
}
