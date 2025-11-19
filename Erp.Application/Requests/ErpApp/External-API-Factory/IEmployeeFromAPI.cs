using Erp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.External_API_Factory
{
    public interface IEmployeeFromAPI
    {
        Task<List<APIEmployeeInfoDto>> EmployeeData(string EmployeeId);
        Task<List<APIEmployeeInfoDto>> EmployeeDataByUnit(string Unit);
        Task<List<APIEmployeeInfoDto>> GetSnowtexAllEmployee();
        Task<List<APIEmployeeInfoDto>> GetSaRaEmployeeListAll();
        Task<List<APIEmployeeInfoDto>> GetSaRaCorporateEmployeeList();        
        Task<List<DailyAttendanceDto>> GetDailyAttendanceSummary();
        Task<Result> EmployeeSync(APIEmployeeInfoDto model);
        Task<Result> LocalSupplierSync();
        Task<List<APIEmployeeInfoDto>> GetSaRaEmployeeDataByUnit(string unit);
        Task<List<APITaxableEmployeeInfoDto>> GetSnowtexAllTaxPayableEmployee();
        Task<Result> TaxPayableEmployeeSync(APITaxableEmployeeInfoDto model);

    }
}
