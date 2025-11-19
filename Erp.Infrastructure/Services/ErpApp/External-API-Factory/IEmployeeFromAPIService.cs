using AutoMapper;
using Dapper;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.External_API_Factory;
using Erp.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Services.ErpApp.External_API_Factory
{
    public class IEmployeeFromAPIService : DbContext<APIEmployeeInfoDto>, IEmployeeFromAPI
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public IEmployeeFromAPIService(IConfiguration configuration, ApplicationDbContext dbContext, ICurrentUserService currentUserService, IMapper mapper) : base(configuration)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<List<APIEmployeeInfoDto>> EmployeeData(string EmployeeId)
        {
            List<APIEmployeeInfoDto> EmployeeDetailsAll = new List<APIEmployeeInfoDto>();
            List<APIEmployeeInfoDto> EmployeeDetailsAllStaff = new List<APIEmployeeInfoDto>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("http://192.168.2.147:100/api/globalapi/getemployeeinformations?id=1&companyName=sng&category=");

                    if (response.IsSuccessStatusCode)
                    {
                        var ObjResponse = response.Content.ReadAsStringAsync().Result;
                        EmployeeDetailsAll = JsonConvert.DeserializeObject<List<APIEmployeeInfoDto>>(ObjResponse);
                        if (EmployeeDetailsAll != null && EmployeeDetailsAll.Count() > 0)
                        {
                            EmployeeDetailsAllStaff = EmployeeDetailsAll.Where(x => x.EmployeeID == EmployeeId).ToList();
                        }
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return EmployeeDetailsAllStaff;
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<List<APIEmployeeInfoDto>> EmployeeDataByUnit(string Unit)
        {
            List<APIEmployeeInfoDto> EmployeeDetailsAll = new List<APIEmployeeInfoDto>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("http://192.168.2.147:100/api/globalapi/getemployeeinformations?id=1&companyName=sng&category=");

                    if (response.IsSuccessStatusCode)
                    {
                        var ObjResponse = response.Content.ReadAsStringAsync().Result;
                        EmployeeDetailsAll = JsonConvert.DeserializeObject<List<APIEmployeeInfoDto>>(ObjResponse);
                        if (EmployeeDetailsAll != null && EmployeeDetailsAll.Count() > 0)
                        {
                            EmployeeDetailsAll = EmployeeDetailsAll.Where(x => x.Company == Unit).ToList();
                        }
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return EmployeeDetailsAll;
        }

        public async Task<List<APIEmployeeInfoDto>> GetSaRaEmployeeListAll()
        {
            List<APIEmployeeInfoDto> EmployeeDetailsAll = new List<APIEmployeeInfoDto>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("http://192.168.2.232/api/Employee/Employees");

                    if (response.IsSuccessStatusCode)
                    {
                        var ObjResponse = response.Content.ReadAsStringAsync().Result;
                        EmployeeDetailsAll = JsonConvert.DeserializeObject<List<APIEmployeeInfoDto>>(ObjResponse);
                        if (EmployeeDetailsAll != null && EmployeeDetailsAll.Count() > 0)
                        {
                            EmployeeDetailsAll = EmployeeDetailsAll.ToList();
                        }
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return EmployeeDetailsAll;
        }

        public async Task<List<DailyAttendanceDto>> GetDailyAttendanceSummary()
        {
            string query = " SELECT * FROM VEW_DAILY_ATTENDANCE";

            var dailuAttendanceList = await GetDisposeErrorFreeListAsync<DailyAttendanceDto>(query, null);

            return dailuAttendanceList.ToList();
        }

        public async Task<List<APIEmployeeInfoDto>> GetSaRaCorporateEmployeeList()
        {
            string query = " SELECT * FROM VEW_EMP_INFO_SARA";

            var corporateSaraEmployees = await GetDisposeErrorFreeListAsync<APIEmployeeInfoDto>(query, null);

            return corporateSaraEmployees.ToList();
        }


        public async Task<List<APITaxableEmployeeInfoDto>> GetSnowtexAllTaxPayableEmployee()
        {
            List<APITaxableEmployeeInfoDto> TaxPayableEmployeeDetailsAll = new List<APITaxableEmployeeInfoDto>();
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync("http://192.168.1.31:91/api/AnotherApps/GetIncomeTaxEmployees?companyCode=04&year=2022&month=8&employeeID=04011119030");

                    if (response.IsSuccessStatusCode)
                    {
                        var ObjResponse = response.Content.ReadAsStringAsync().Result;
                        TaxPayableEmployeeDetailsAll = JsonConvert.DeserializeObject<List<APITaxableEmployeeInfoDto>>(ObjResponse);
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return TaxPayableEmployeeDetailsAll;
        }

        public async Task<Result> TaxPayableEmployeeSync(APITaxableEmployeeInfoDto model)
        {

            string query = "PRO_HR_EMP_TAX_SAVE_API";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_ID", model.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_EMPLOYEE_ID", model.EmployeeID, DbType.String, ParameterDirection.Input);
            parameters.Add("P_EMPLOYEE_NAME", model.EmployeeName, DbType.String, ParameterDirection.Input);
            parameters.Add("P_COMPANY", model.Company, DbType.String, ParameterDirection.Input);
            parameters.Add("P_DESIGNATION", model.Designation, DbType.String, ParameterDirection.Input);
            parameters.Add("P_TIN_NUMBER", model.TinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("P_TAX_AMOUNT", model.TaxAmount, DbType.Double, ParameterDirection.Input);

            parameters.Add("P_CREATE_BY", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
            parameters.Add("p_head_office_id", _currentUserService.HeadOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_branch_office_id", _currentUserService.BranchOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_MESSAGE", "", DbType.String, ParameterDirection.Output);
            return await SetDisposeErrorFreeSingleAsync(query, parameters);
        }


        public async Task<List<APIEmployeeInfoDto>> GetSnowtexAllEmployee()
        {
            List<APIEmployeeInfoDto> EmployeeDetailsAll = new List<APIEmployeeInfoDto>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    HttpResponseMessage response = await client.GetAsync("http://192.168.2.147:100/api/globalapi/getemployeeinformations?id=1&companyName=sng&category=");

                    if (response.IsSuccessStatusCode)
                    {
                        var ObjResponse = response.Content.ReadAsStringAsync().Result;
                        EmployeeDetailsAll = JsonConvert.DeserializeObject<List<APIEmployeeInfoDto>>(ObjResponse);
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }


            return EmployeeDetailsAll;
        }

        public async Task<Result> EmployeeSync(APIEmployeeInfoDto model)
        {

            string query = "PRO_HR_EMPLOYEE_SAVE_API";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_ID", model.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("P_EMPLOYEE_ID", model.EmployeeID, DbType.String, ParameterDirection.Input);
            parameters.Add("P_EMPLOYEE_NAME", model.EmployeeName, DbType.String, ParameterDirection.Input);
            parameters.Add("P_DATE_OF_JOIN", model.Doj, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("P_COMPANY", model.Company, DbType.String, ParameterDirection.Input);
            parameters.Add("P_UNIT", model.Unit, DbType.String, ParameterDirection.Input);
            parameters.Add("P_DEPARTMENT", model.Department, DbType.String, ParameterDirection.Input);
            parameters.Add("P_DESIGNATION", model.Designation, DbType.String, ParameterDirection.Input);
            parameters.Add("P_SECTION", model.Section, DbType.String, ParameterDirection.Input);
            parameters.Add("P_FLOOR", model.Floor, DbType.String, ParameterDirection.Input);
            parameters.Add("P_STAFF_CATEGORY", model.StaffCategory, DbType.String, ParameterDirection.Input);
            parameters.Add("P_ACTIVE_STATUS", model.Active, DbType.Int32, ParameterDirection.Input);

            parameters.Add("P_CREATE_BY", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
            parameters.Add("p_head_office_id", _currentUserService.HeadOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_branch_office_id", _currentUserService.BranchOfficeId, DbType.Int32, ParameterDirection.Input);

            parameters.Add("P_MESSAGE", "", DbType.String, ParameterDirection.Output);
            return await SetDisposeErrorFreeSingleAsync(query, parameters);
        }

        public async Task<Result> LocalSupplierSync()
        {
            string query = "PRO_LOCAL_SUPPLIER_FAC_SAVE";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("P_CREATE_BY", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
            parameters.Add("p_head_office_id", _currentUserService.HeadOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("p_branch_office_id", _currentUserService.BranchOfficeId, DbType.Int32, ParameterDirection.Input);

            parameters.Add("P_MESSAGE", "", DbType.String, ParameterDirection.Output);
            return await SetDisposeErrorFreeSingleAsync(query, parameters);
        }

        public async Task<List<APIEmployeeInfoDto>> GetSaRaEmployeeDataByUnit(string unit)
        {
            List<APIEmployeeInfoDto> EmployeeDetailsAll = new List<APIEmployeeInfoDto>();
            List<APIEmployeeInfoDto> FinalEmployeeDetailsAll = new List<APIEmployeeInfoDto>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("http://192.168.2.147:100/api/globalapi/getemployeeinformations?id=1&companyName=sng&category=WOT,FS-WOT,W");

                    if (response.IsSuccessStatusCode)
                    {
                        var ObjResponse = response.Content.ReadAsStringAsync().Result;
                        EmployeeDetailsAll = JsonConvert.DeserializeObject<List<APIEmployeeInfoDto>>(ObjResponse);
                        if (EmployeeDetailsAll != null && EmployeeDetailsAll.Count() > 0)
                        {
                            FinalEmployeeDetailsAll = EmployeeDetailsAll.Where(x => x.Unit == unit).ToList();

                        }
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return FinalEmployeeDetailsAll;            
        }
    }
}
