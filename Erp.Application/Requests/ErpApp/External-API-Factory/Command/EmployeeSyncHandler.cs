using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.External_API_Factory.Command
{
    public class EmployeeSyncHandler : IRequestHandler<EmployeeSync, Result>
    {
        private readonly IEmployeeFromAPI _employeeFromAPI;
        public EmployeeSyncHandler(IEmployeeFromAPI employeeFromAPI)
        {
            _employeeFromAPI = employeeFromAPI;
        }
        public async Task<Result> Handle(EmployeeSync request, CancellationToken cancellationToken)
        {

            var stEmployees = await _employeeFromAPI.GetSnowtexAllEmployee();
            //var saraEmployees = await _employeeFromAPI.GetSaRaEmployeeListAll();
            List<APIEmployeeInfoDto> finalEmpList = new List<APIEmployeeInfoDto>();

            finalEmpList.AddRange((IEnumerable<APIEmployeeInfoDto>)stEmployees);
            //finalEmpList.AddRange((IEnumerable<APIEmployeeInfoDto>)saraEmployees);



            foreach (var item in finalEmpList)
            {
                var model = new APIEmployeeInfoDto
                {
                    Id = item.Id,
                    EmployeeID = item.EmployeeID,
                    Unit = item.Unit,
                    EmployeeName = item.EmployeeName,
                    Department = item.Department,
                    Doj = item.Doj,
                    Company = item.Company,
                    Designation = item.Designation,
                    Section = item.Section,
                    Floor = item.Floor,
                    StaffCategory = item.StaffCategory,
                    Active = item.Active
                };
                var res = await _employeeFromAPI.EmployeeSync(model);

            }
            return Result.Success();









        }
    }


    public class TaxableEmployeeSyncHandler : IRequestHandler<TaxableEmployeeSync, Result>
    {
        private readonly IEmployeeFromAPI _employeeFromAPI;
        public TaxableEmployeeSyncHandler(IEmployeeFromAPI employeeFromAPI)
        {
            _employeeFromAPI = employeeFromAPI;
        }
        public async Task<Result> Handle(TaxableEmployeeSync request, CancellationToken cancellationToken)
        {

            var stEmployees = await _employeeFromAPI.GetSnowtexAllTaxPayableEmployee();
            List<APITaxableEmployeeInfoDto> finalEmpList = new List<APITaxableEmployeeInfoDto>();

            finalEmpList.AddRange((IEnumerable<APITaxableEmployeeInfoDto>)stEmployees);

            foreach (var item in finalEmpList)
            {
                var model = new APITaxableEmployeeInfoDto
                {
                    Id = item.Id,
                    EmployeeID = item.EmployeeID,
                    EmployeeName = item.EmployeeName,
                    Company = item.Company,
                    Designation = item.Designation,
                    TinNumber = item.TinNumber,
                    TaxAmount = item.TaxAmount
                   
                };
                var res = await _employeeFromAPI.TaxPayableEmployeeSync(model);

            }
            return Result.Success();









        }
    }


}
