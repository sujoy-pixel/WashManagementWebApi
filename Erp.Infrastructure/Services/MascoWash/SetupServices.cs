using Castle.Core;
using Dapper;
using Erp.Application.Auth.RoleManagement;

using Erp.Application.Commercial.Setup;
using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using Erp.Domain.Entities.Commercial.Setup;
using Erp.Infrastructure.Persistence;
using FluentValidation.Validators;
using MailKit.Search;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erp.Infrastructure.Services.MascoWash
{
    public class SetupServices : DbContext<SaveDataList>, ISaveDataList, ISetup
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISaveDataList _setupService;
        public SetupServices(ICurrentUserService currentUserService, IConfiguration configuration, ApplicationDbContext dbcontext) : base(configuration)
        {
            _dbContext = dbcontext;
            _currentUserService = currentUserService;

        }

        public async Task<Result> CreateDataList(SaveDataListDto saveDataListDto)
        {

            List<CreateMenuPermisionObj> list = new List<CreateMenuPermisionObj>();
            List<DetailList> listDetail = saveDataListDto.detail.ToList();

            DataTable dataTable = ListToDataTableConversion.ConvertListToDataTable(listDetail);
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Data_Table_Param";
            parameter.Add("@TableParam", dataTable.AsTableValuedParameter());
            var GetMenuList = await GetDataByDataTable<CreateMenuPermisionObj>(query, parameter, dataTable);

            return Result.Success();
        }

                                                 /// Process Name Entry ///

        public async Task<WrapperResponseProcessName> saveProcessNameEntryData(saveProcessNameData saveDataListDto)
        {
            var response = new WrapperResponseProcessName();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Update_Delete_SaveProcessName";

            parameter.Add("@Operation", saveDataListDto.Operation, DbType.String);
            parameter.Add("@ProcessId", saveDataListDto.ProcessId, DbType.Int32);
            parameter.Add("@UnitId", saveDataListDto.UnitId, DbType.Int32);
            parameter.Add("@ProcessName", saveDataListDto.ProcessName, DbType.String);
            parameter.Add("@Priority", saveDataListDto.Priority, DbType.Int32);
            parameter.Add("@IsActive", saveDataListDto.IsActive, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String);


            DataTable result = await GetDataByDataTable(query, parameter);
            if (result != null && result.Rows.Count > 0)
            {
                // Assuming the stored procedure returns a column named 'SupResponse'
                response.ResultCode = result.Rows[0]["ResultCode"].ToString();
            }
            else
            {
                response.ResultCode = "No data returned.";
            }

            return response;
        }



        public async Task<List<ProcessNameEntryGetList>> GetProcessNameEntryList()
        {

            List<ProcessNameEntryGetList> list = new List<ProcessNameEntryGetList>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_ProcessNameEntry";
            //parameter.Add("@searchTerm", searchTerm, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<ProcessNameEntryGetList>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new ProcessNameEntryGetList
                {
                    ProcessId = item.ProcessId,
                    ProcessName = item.ProcessName,
                    UnitId = item.UnitId,
                    UnitEName = item.UnitEName,
                    Priority = item.Priority,
                    IsActive = item.IsActive

                };
                list.Add(obj);

            }

            return list;

        }

        public async Task<List<DropdownListDto1>> GetUnitNameList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_UnitName";

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName

                };
                list.Add(obj);

            }

            return list;
        }


                                                     /// Operation Name Entry ///

        public async Task<WrapperResponseOperationName> saveOperationNameEntryData(saveOperationNameData saveDataListDto)
        {
            var response = new WrapperResponseOperationName();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Update_Delete_SaveOperationName";

            parameter.Add("@Operation", saveDataListDto.Operation, DbType.String);
            parameter.Add("@OperationId", saveDataListDto.OperationId, DbType.Int32);
            parameter.Add("@OperationName", saveDataListDto.OperationName, DbType.String);
            parameter.Add("@Priority", saveDataListDto.Priority, DbType.Int32);
            parameter.Add("@IsActive", saveDataListDto.IsActive, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String);


            DataTable result = await GetDataByDataTable(query, parameter);
            if (result != null && result.Rows.Count > 0)
            {
                response.ResultCode = result.Rows[0]["ResultCode"].ToString();
            }
            else
            {
                response.ResultCode = "No data returned.";
            }

            return response;
        }


        public async Task<List<OperationNameEntryGetList>> GetOperationNameEntryList()
        {

            List<OperationNameEntryGetList> list = new List<OperationNameEntryGetList>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_OperationNameEntry";

            var GetList = await GetDisposeErrorFreeListAsyncNew<OperationNameEntryGetList>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new OperationNameEntryGetList
                {
                    OperationId = item.OperationId,
                    OperationName = item.OperationName,
                    Priority = item.Priority,
                    IsActive = item.IsActive

                };
                list.Add(obj);

            }

            return list;

        }

                                                         /// Type of Inspection ///

        public async Task<WrapperResponseTypeofInspection> saveTypeofInspectionData(saveTypeofInspectionData saveDataListDto)
        {
            var response = new WrapperResponseTypeofInspection();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Update_Delete_SaveTypeofInspection";

            parameter.Add("@Operation", saveDataListDto.Operation, DbType.String);
            parameter.Add("@TypeofInspectionId", saveDataListDto.TypeofInspectionId, DbType.Int32);
            parameter.Add("@TypeName", saveDataListDto.TypeName, DbType.String);
            //parameter.Add("@Priority", saveDataListDto.Priority, DbType.Int32);
            parameter.Add("@IsActive", saveDataListDto.IsActive, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String);


            DataTable result = await GetDataByDataTable(query, parameter);
            if (result != null && result.Rows.Count > 0)
            {
                response.ResultCode = result.Rows[0]["ResultCode"].ToString();
            }
            else
            {
                response.ResultCode = "No data returned.";
            }

            return response;
        }
        public async Task<List<TypeofInspectionGetList>> GetTypeofInspectionList()
        {

            List<TypeofInspectionGetList> list = new List<TypeofInspectionGetList>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_TypeofInspection";

            var GetList = await GetDisposeErrorFreeListAsyncNew<TypeofInspectionGetList>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new TypeofInspectionGetList
                {
                    TypeofInspectionId = item.TypeofInspectionId,
                    TypeName = item.TypeName,
                    Priority = item.Priority,
                    IsActive = item.IsActive

                };
                list.Add(obj);

            }

            return list;

        }



                                                           /// Inspection Area ///

        public async Task<WrapperResponseInspectionArea> saveInspectionAreaData(saveInspectionAreaData saveDataListDto)
        {
            var response = new WrapperResponseInspectionArea();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Update_Delete_SaveInspectionArea";

            parameter.Add("@Operation", saveDataListDto.Operation, DbType.String);
            parameter.Add("@InspectionAreaId", saveDataListDto.InspectionAreaId, DbType.Int32);
            parameter.Add("@InspectionArea", saveDataListDto.InspectionArea, DbType.String);
            parameter.Add("@Priority", saveDataListDto.Priority, DbType.Int32);
            parameter.Add("@IsActive", saveDataListDto.IsActive, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String);


            DataTable result = await GetDataByDataTable(query, parameter);
            if (result != null && result.Rows.Count > 0)
            {
                response.ResultCode = result.Rows[0]["ResultCode"].ToString();
            }
            else
            {
                response.ResultCode = "No data returned.";
            }

            return response;
        }
        public async Task<List<InspectionAreaGetList>> GetInspectionAreaList()
        {

            List<InspectionAreaGetList> list = new List<InspectionAreaGetList>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_InspectionArea";

            var GetList = await GetDisposeErrorFreeListAsyncNew<InspectionAreaGetList>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new InspectionAreaGetList
                {
                    InspectionAreaId = item.InspectionAreaId,
                    InspectionArea = item.InspectionArea,
                    Priority = item.Priority,
                    IsActive = item.IsActive

                };
                list.Add(obj);

            }

            return list;

        }


                                                    /// Fault Head Name Layout ///

        public async Task<WrapperResponseFaultHead> saveFaultHeadData(saveFaultHeadData saveDataListDto)
        {
            var response = new WrapperResponseFaultHead();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Update_Delete_SaveFaultHead";

            parameter.Add("@Operation", saveDataListDto.Operation, DbType.String);
            parameter.Add("@FaultHeadId", saveDataListDto.FaultHeadId, DbType.Int32);
            parameter.Add("@CodeNo", saveDataListDto.CodeNo, DbType.Int32);
            parameter.Add("@FaultHeadName", saveDataListDto.FaultHeadName, DbType.String);
            parameter.Add("@Priority", saveDataListDto.Priority, DbType.Int32);
            parameter.Add("@IsActive", saveDataListDto.IsActive, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String);


            DataTable result = await GetDataByDataTable(query, parameter);
            if (result != null && result.Rows.Count > 0)
            {
                // Assuming the stored procedure returns a column named 'SupResponse'
                response.ResultCode = result.Rows[0]["ResultCode"].ToString();
            }
            else
            {
                response.ResultCode = "No data returned.";
            }

            return response;
        }



        public async Task<List<FaultHeadGetList>> GetFaultHeadList()
        {

            List<FaultHeadGetList> list = new List<FaultHeadGetList>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_FaultHead";
            //parameter.Add("@searchTerm", searchTerm, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<FaultHeadGetList>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new FaultHeadGetList
                {
                    FaultHeadId = item.FaultHeadId,
                    FaultHeadName = item.FaultHeadName,
                    CodeNo = item.CodeNo,
                    Priority = item.Priority,
                    IsActive = item.IsActive

                };
                list.Add(obj);

            }

            return list;

        }


                                                     /// Inspection Head Layout ///

        public async Task<WrapperResponseInspectionHead> saveInspectionHeadData(saveInspectionHeadData saveDataListDto)
        {
            var response = new WrapperResponseInspectionHead();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Update_Delete_SaveInspectionHead";

            parameter.Add("@Operation", saveDataListDto.Operation, DbType.String);
            parameter.Add("@InspectionHeadId", saveDataListDto.InspectionHeadId, DbType.Int32);
            parameter.Add("@HeadName", saveDataListDto.HeadName, DbType.String);
            parameter.Add("@Priority", saveDataListDto.Priority, DbType.Int32);
            parameter.Add("@IsActive", saveDataListDto.IsActive, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String);


            DataTable result = await GetDataByDataTable(query, parameter);
            if (result != null && result.Rows.Count > 0)
            {
                // Assuming the stored procedure returns a column named 'SupResponse'
                response.ResultCode = result.Rows[0]["ResultCode"].ToString();
            }
            else
            {
                response.ResultCode = "No data returned.";
            }

            return response;
        }



        public async Task<List<InspectionHeadGetList>> GetInspectionHeadList()
        {

            List<InspectionHeadGetList> list = new List<InspectionHeadGetList>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_InspectionHead";
            //parameter.Add("@searchTerm", searchTerm, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<InspectionHeadGetList>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new InspectionHeadGetList
                {
                    InspectionHeadId = item.InspectionHeadId,
                    HeadName = item.HeadName,
                    Priority = item.Priority,
                    IsActive = item.IsActive

                };
                list.Add(obj);

            }

            return list;

        }


                                                    /// Fault Name Layout ///

        public async Task<WrapperResponseFaultName> saveFaultNameData(saveFaultNameData saveDataListDto)
        {
            var response = new WrapperResponseFaultName();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Insert_Update_Delete_SaveFaultName";

            parameter.Add("@Operation", saveDataListDto.Operation, DbType.String);
            parameter.Add("@FaultNameId", saveDataListDto.FaultNameId, DbType.Int32);
            parameter.Add("@FaultName", saveDataListDto.FaultName, DbType.String);
            parameter.Add("@FaultHeadId", saveDataListDto.FaultHeadId, DbType.String);
            parameter.Add("@CodeNo", saveDataListDto.CodeNo, DbType.String);
            parameter.Add("@Priority", saveDataListDto.Priority, DbType.Int32);
            parameter.Add("@IsActive", saveDataListDto.IsActive, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String);


            DataTable result = await GetDataByDataTable(query, parameter);
            if (result != null && result.Rows.Count > 0)
            {
                // Assuming the stored procedure returns a column named 'SupResponse'
                response.ResultCode = result.Rows[0]["ResultCode"].ToString();
            }
            else
            {
                response.ResultCode = "No data returned.";
            }

            return response;
        }



        public async Task<List<FaultNameGetList>> GetFaultNameList()
        {

            List<FaultNameGetList> list = new List<FaultNameGetList>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_FaultName";
            //parameter.Add("@searchTerm", searchTerm, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<FaultNameGetList>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new FaultNameGetList
                {
                    FaultNameId = item.FaultNameId,
                    FaultName = item.FaultName,
                    FaultHeadId = item.FaultHeadId,
                    FaultHeadName = item.FaultHeadName,
                    CodeNo = item.CodeNo,
                    Priority = item.Priority,
                    IsActive = item.IsActive

                };
                list.Add(obj);

            }

            return list;

        }
        public async Task<List<DropdownListDto1>> GetFaultHeadDDLList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_FaultHeadDDL";

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName

                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetInspectionHeadDDLList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_InspectionHeadDDL";

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName

                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetOperationNameDDLList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_OperationNameDDL";

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName

                };
                list.Add(obj);

            }

            return list;
        }
        public async Task<List<DropdownListDto>> GetReportName(string ReportMenu, string UserId)
        {

            List<DropdownListDto> list = new List<DropdownListDto>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Menu_Wise_Report_Load";
            parameter.Add("@ParentMenu", ReportMenu, DbType.String, ParameterDirection.Input);
            parameter.Add("@UserId", UserId, DbType.String, ParameterDirection.Input);
            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName
                };
                list.Add(obj);

            }

            return list;

        }


     
    }
}
