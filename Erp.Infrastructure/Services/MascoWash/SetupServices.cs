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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Erp.Infrastructure.Services.MascoWash.SetupServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erp.Infrastructure.Services.MascoWash
{
    public class SetupServices : DbContext<SaveDataList>, ISaveDataList, ISetup
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly string _connectionString;
        private readonly ISaveDataList _setupService;
        private readonly IDbConnection _con;

        public SetupServices(ICurrentUserService currentUserService, IConfiguration configuration, ApplicationDbContext dbcontext) : base(configuration)
        {
            _dbContext = dbcontext;
            _currentUserService = currentUserService;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _con = base.GetType()
                .GetField("_con", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(this) as IDbConnection;
        }

        // Helper method to create connection
        private IDbConnection CreateConnection()
        {
            var conn = new SqlConnection(_connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            return conn;
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
                    //Priority = item.Priority,
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

        public async Task<WrapperResponseInspectionArea> DeleteInspectionsArea(saveInspectionAreaData saveDataListDto)
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




        public async Task<List<MachineDuplicateCheckModel>> CheckMachineExists(int unitId, int operationId, string machineName)
        {
            List<MachineDuplicateCheckModel> list = new List<MachineDuplicateCheckModel>();

            DynamicParameters parameter = new DynamicParameters();
            string query = "Duplicate_Check_SaveMachineMasterDetailEntry";

            parameter.Add("@UnitId", unitId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@OperationId", operationId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@MachineName", machineName, DbType.String, ParameterDirection.Input);

            var getList =
                await GetDisposeErrorFreeListAsyncNew<MachineDuplicateCheckModel>(
                    query,
                    parameter
                );

            foreach (var item in getList)
            {
                var obj = new MachineDuplicateCheckModel
                {
                    ExistsFlag = item.ExistsFlag
                };

                list.Add(obj);
            }

            return list;
        }

        public async Task<WrapperResponseFaultWiseValueTag> saveFaultWiseValueTagData(saveFaultWiseValueTagData saveDataDto)
        {
            var response = new WrapperResponseFaultWiseValueTag();
            DynamicParameters parameter = new DynamicParameters();

            string query = "sp_Insert_Update_Delete_SaveFaultWiseValueTag";

            parameter.Add("@Operation", saveDataDto.Operation, DbType.String);
            parameter.Add("@FaultWiseMasterId", saveDataDto.FaultWiseMasterId, DbType.Int32);
            parameter.Add("@Type", saveDataDto.Type, DbType.String);
            parameter.Add("@InspectionHeadId", saveDataDto.InspectionHeadId, DbType.Int32);
            parameter.Add("@FaultHeadId", saveDataDto.FaultHeadId, DbType.Int32);
            parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.Int32);

            DataTable tvpTable = new DataTable();
            tvpTable.Columns.Add("FaultWiseMasterId", typeof(int));
            tvpTable.Columns.Add("FaultNameId", typeof(int));
            tvpTable.Columns.Add("Value", typeof(decimal));
            tvpTable.Columns.Add("IsChecked", typeof(bool));

            if (saveDataDto.FaultWiseDetails != null && saveDataDto.FaultWiseDetails.Count > 0)
            {
                foreach (var item in saveDataDto.FaultWiseDetails)
                {
                    tvpTable.Rows.Add(
                        item.FaultWiseMasterId,
                        item.FaultNameId,
                        item.Value,
                        item.IsChecked ? 1 : 0
                    );
                }
            }

            parameter.Add(
                "@TableParam",
                tvpTable.AsTableValuedParameter("dbo.tbl_FaultWiseType")
            );

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
        public async Task<List<FaultWiseValueTagDetailGetAll>> GetFaultWiseValueTagList()
        {

            List<FaultWiseValueTagDetailGetAll> list = new List<FaultWiseValueTagDetailGetAll>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_GetAll_FaultWiseValueTag";

            var GetList = await GetDisposeErrorFreeListAsyncNew<FaultWiseValueTagDetailGetAll>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new FaultWiseValueTagDetailGetAll
                {
                    FaultWiseMasterId = item.FaultWiseMasterId,
                    Type = item.Type,
                    InspectionHeadId = item.InspectionHeadId,
                    FaultHeadId = item.FaultHeadId,
                    FaultWiseDetailsId = item.FaultWiseDetailsId,
                    FaultNameId = item.FaultNameId,
                    Value = item.Value,
                    IsChecked = item.IsChecked

                };
                list.Add(obj);

            }

            return list;

        }


        public async Task<List<FaultWiseValueTagDetailGetAll>> GetFaultWiseValueTagListByFaultWiseMasterId(int FaultWiseMasterId)
        {

            List<FaultWiseValueTagDetailGetAll> list = new List<FaultWiseValueTagDetailGetAll>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_GetAll_FaultWiseValueTagByFaultMasterId";
            parameter.Add("@FaultWiseMasterId", FaultWiseMasterId, DbType.Int32, ParameterDirection.Input);
            var GetList = await GetDisposeErrorFreeListAsyncNew<FaultWiseValueTagDetailGetAll>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new FaultWiseValueTagDetailGetAll
                {
                    FaultWiseMasterId = item.FaultWiseMasterId,
                    Type = item.Type,
                    InspectionHeadId = item.InspectionHeadId,
                    FaultHeadId = item.FaultHeadId,
                    FaultWiseDetailsId = item.FaultWiseDetailsId,
                    FaultNameId = item.FaultNameId,
                    Value = item.Value,
                    IsChecked = item.IsChecked

                };
                list.Add(obj);

            }

            return list;

        }

        public async Task<List<MachineMasterDetailModel>> GetMachineMasterList()
        {
            List<MachineMasterDetailModel> list = new List<MachineMasterDetailModel>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_MachineMasterDetail_List";

            var getList = await GetDisposeErrorFreeListAsyncNew<MachineMasterDetailModel>(query, parameter);

            foreach (var item in getList)
            {
                var obj = new MachineMasterDetailModel
                {
                    MachineNameMasterId = item.MachineNameMasterId,
                    UnitId = item.UnitId,
                    UnitName = item.UnitName,
                    OperationId = item.OperationId,
                    OperationName = item.OperationName,
                    MachineDetailId = item.MachineDetailId,
                    MachineName = item.MachineName,
                    IsActive = item.IsActive
                };
                list.Add(obj);
            }

            return list;
        }


        public async Task<Result> saveMachineName(SaveMachineName dto)
        {


            if (dto == null)
                return Result.Failure(new[] { "Request data is null" });

            //if (dto._listData == null || !dto._listData.Any())
            //    return Result.Failure(new[] { "Machine detail list is empty" });

            // Convert list to DataTable for TVP
            var dataTable = ListToDataTableConversion.ConvertListToDataTable(dto._listData);

            var parameter = new DynamicParameters();
            parameter.Add("@Operation", dto.Operation);
            parameter.Add("@UnitId", dto.UnitId);
            parameter.Add("@OperationId", dto.OperationId);
            parameter.Add("@MasterId", dto.MasterId); // Nullable int
            parameter.Add("@CreatedBy", _currentUserService?.EmployeeId ?? "SYSTEM");
            parameter.Add("@TableParam", dataTable.AsTableValuedParameter("dbo.tbl_Save_List_Master_Detail_MachineEntry"));

            try
            {
                using var conn = CreateConnection();
                int affectedRows = await conn.ExecuteAsync(
                    "[dbo].[sp_Insert_Update_Delete_SaveMachineMasterDetailEntry]",
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return affectedRows > 0
                    ? Result.Success("Saved successfully")
                    : Result.Failure(new[] { "No rows affected by database operation" });
            }
            catch (SqlException ex)
            {
                return Result.Failure(new[] { $"Database error: {ex.Message}" });
            }
            catch (System.Exception ex)
            {
                return Result.Failure(new[] { $"Unexpected error: {ex.Message}" });
            }
        }

        public async Task<List<DropdownListDto1>> GetBuyerDDLList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Buyer";

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

        public async Task<List<DropdownListDto1>> GetJobDDLList(string itemText)
        {

            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Job";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }


        public async Task<List<DropdownListDto1>> GetStyleDDLList(string itemText)
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Style";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

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

        public async Task<List<DropdownListDto1>> GetOrderDDLList(string itemText)
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Order";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

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

        public async Task<List<DropdownListDto1>> GetTypeDDLList()
        {
            var list = new List<DropdownListDto1>
    {
        new DropdownListDto1 { ID = 1, DisplayName = "Fabrics" },
        new DropdownListDto1 { ID = 2, DisplayName = "Gmt" },
        new DropdownListDto1 { ID = 3, DisplayName = "Cutting points" }
    };

            return await Task.FromResult(list);
        }

        public async Task<List<DropdownListDto1>> GetFabricationDDLList(string itemText)
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Fabrication";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetGSMDDLList(string itemText)
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_GSM";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetDressPartDDLList(string itemText)
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_DressPart";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetUOMDDLList(string itemText)
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_UOM";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetTrackingNoDDLList(string itemText)
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_TrackingNo";
            parameter.Add("@ItemText", itemText, DbType.String, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    DisplayName = item.DisplayName
                };
                list.Add(obj);

            }

            return list;
        }




        public async Task<List<TrackingNoWiseReceiveDto>> GetReceiveDataList(string trackingNo)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TrackingNo", trackingNo);

            const string spName = "[dbo].[tbl_SP_GetTrackingNoWiseReceiveData]";

            var result = await GetDisposeErrorFreeListAsyncNew<TrackingNoWiseReceiveDto>(
                spName,
                parameter
            );

            return result?.ToList() ?? new List<TrackingNoWiseReceiveDto>();
        }

        public async Task<List<TrackingNoWiseReceiveDto>> GetReceiveDataListBatchNo(string batchNo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@BatchNo", batchNo);

            const string spName = "[dbo].[tbl_SP_GetBatchNoWiseReceiveData]";

            var result = await GetDisposeErrorFreeListAsyncNew<TrackingNoWiseReceiveDto>(
                spName,
                parameter
            );

            return result?.ToList() ?? new List<TrackingNoWiseReceiveDto>();
        }



        public async Task<List<DropdownListDto1>> GetTypeOfInspectionDDLList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_TypeOfInspectionDDL";

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

        public async Task<Result> SaveTrackingReceive(SaveTrackingNoReceive dto)
        {
            if (dto?.Master == null)
                return Result.Failure(new[] { "Invalid request" });

            var operation = dto.Master.Operation?.ToUpper();

            var tvpRows = new List<WashReceiveTvpRow>();

            foreach (var d in dto.Details)
            {
                foreach (var s in d.SizeDetails)
                {
                    tvpRows.Add(new WashReceiveTvpRow
                    {
                        TrackingBatchNo = d.TrackingBatchNo,
                        FromUnitId = d.FromUnitId,
                        BuyerId = d.BuyerId,
                        JobId = d.JobId,
                        StyleId = d.StyleId,
                        OrderId = d.StyleId,
                        TypeName = d.TypeName,
                        FabricationId = d.FabricationId,
                        Composition = d.Composition,
                        GsmId = d.GsmId,
                        SizeId = s.SizeId,
                        ColorId = d.ColorId,
                        DressPartId = d.DressPartId,
                        OperationType = d.OperationType,
                        UOMId = d.UOMId,
                        Size = s.Size,
                        Qty = s.Qty,
                        ProbableDeliveryDate = d.ProbableDeliveryDate,
                        ShipmentDate = d.ShipmentDate
                    });
                }
            }

            if (!tvpRows.Any())
                return Result.Failure(new[] { "No size rows generated" });

            var table = CreateWashReceiveTvpTable(tvpRows);

            var param = new DynamicParameters();
            param.Add("@Operation", operation);
            param.Add("@UnitId", dto.Master.UnitId);
            param.Add("@TrackingNo", dto.Master.TrackingNo);
            param.Add("@MasterId", dto.Master.MasterId);
            param.Add("@CreatedBy", _currentUserService?.EmployeeId ?? "SYSTEM");
            param.Add("@DetailsTVP",
                table.AsTableValuedParameter("dbo.tbl_Wash_Receive_Operation_TVP"));

            using var conn = CreateConnection();
            var result = await conn.QueryFirstOrDefaultAsync<ReceiveResult>(
    "[dbo].[sp_Save_Wash_Order_Receive_Operation]",
    param,
    commandType: CommandType.StoredProcedure);

            if (result == null || result.ResultCode == 0)
                return Result.Failure(new[] { result?.Message ?? "Save failed" });

            return Result.Success(JsonConvert.SerializeObject(result));



        }

        // 🔥 HELPER METHOD (MUST BE HERE)
        private DataTable CreateWashReceiveTvpTable(List<WashReceiveTvpRow> rows)
        {
            var dt = new DataTable();

            dt.Columns.Add("TrackingBatchNo", typeof(string));
            dt.Columns.Add("FromUnitId", typeof(int));
            dt.Columns.Add("BuyerId", typeof(int));
            dt.Columns.Add("JobId", typeof(int));
            dt.Columns.Add("StyleId", typeof(int));
            dt.Columns.Add("OrderId", typeof(int));
            dt.Columns.Add("TypeName", typeof(string));
            dt.Columns.Add("FabricationId", typeof(int));
            dt.Columns.Add("Composition", typeof(string));
            dt.Columns.Add("GsmId", typeof(int));
            dt.Columns.Add("SizeId", typeof(int));
            dt.Columns.Add("ColorId", typeof(int));
            dt.Columns.Add("DressPartId", typeof(int));
            dt.Columns.Add("OperationType", typeof(string));
            dt.Columns.Add("UOMId", typeof(int));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("Qty", typeof(decimal));
            dt.Columns.Add("ProbableDeliveryDate", typeof(DateTime));
            dt.Columns.Add("ShipmentDate", typeof(DateTime));

            foreach (var r in rows)
            {
                dt.Rows.Add(
                    r.TrackingBatchNo,
                    r.FromUnitId,
                    r.BuyerId,
                    r.JobId,
                    r.StyleId,
                    r.OrderId,
                    r.TypeName ?? (object)DBNull.Value,
                    r.FabricationId,
                    r.Composition ?? (object)DBNull.Value,
                    r.GsmId ?? (object)DBNull.Value,
                    r.SizeId,
                    r.ColorId ?? (object)DBNull.Value,
                    r.DressPartId ?? (object)DBNull.Value,
                    r.OperationType ?? (object)DBNull.Value,
                    r.UOMId ?? (object)DBNull.Value,
                    r.Size,
                    r.Qty,
                    r.ProbableDeliveryDate ?? (object)DBNull.Value,
                    r.ShipmentDate ?? (object)DBNull.Value
                );
            }

            return dt;
        }

        public async Task<List<TrackingNoWiseReceiveDto>> GetDataBySearchForEditService(
     int unitId,
     string receiveNo,
     string fromDate,
     string toDate)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UnitId", unitId, DbType.Int32);

            parameter.Add("@ReceiveNo",
                string.IsNullOrWhiteSpace(receiveNo) ? null : receiveNo,
                DbType.String);

            parameter.Add("@FromDate",
                string.IsNullOrWhiteSpace(fromDate) ? null : fromDate,
                DbType.String);

            parameter.Add("@ToDate",
                string.IsNullOrWhiteSpace(toDate) ? null : toDate,
                DbType.String);

            const string spName = "[dbo].[tbl_SP_GetDataBySearchForEdit]";

            var result = await GetDisposeErrorFreeListAsyncNew<TrackingNoWiseReceiveDto>(
                spName,
                parameter
            );

            return result?.ToList() ?? new List<TrackingNoWiseReceiveDto>();
        }

        public async Task<List<DropdownListDto1>> GetJobDDLListData(int unitId, int buyerId)
        {

            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Job_BY_Unit_Buyer";
            parameter.Add("@UnitId", unitId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@BuyerId", buyerId, DbType.Int32, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetStyleDDLListData(int unitId, int buyerId, int jobId)
        {

            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Style_By_Unit_Buyer_Job";
            parameter.Add("@UnitId", unitId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@BuyerId", buyerId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@JobId", jobId, DbType.Int32, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }

        public async Task<List<DropdownListDto1>> GetOrderDDLListData(int unitId, int buyerId, int jobId, int styleId)
        {

            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_Order_By_Unit_Buyer_Job_Style";
            parameter.Add("@UnitId", unitId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@BuyerId", buyerId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@JobId", jobId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@StyleId", styleId, DbType.Int32, ParameterDirection.Input);

            var GetList = await GetDisposeErrorFreeListAsyncNew<DropdownListDto1>(query, parameter);
            foreach (var item in GetList)
            {
                var obj = new DropdownListDto1
                {
                    ID = item.ID,
                    DisplayName = item.DisplayName,
                    Option1 = item.Option1
                };
                list.Add(obj);

            }

            return list;
        }
        public async Task<List<TrackingNoWiseReceiveDto>> GetBatchPrepareDataList(int unitId, int buyerId, int jobId, int styleId, int orderId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UnitId", unitId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@BuyerId", buyerId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@JobId", jobId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@StyleId", styleId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@OrderId", orderId, DbType.Int32, ParameterDirection.Input);

            const string spName = "[dbo].[tbl_SP_GetBatchPrepareDataListeData]";

            var result = await GetDisposeErrorFreeListAsyncNew<TrackingNoWiseReceiveDto>(
                spName,
                parameter
            );

            return result?.ToList() ?? new List<TrackingNoWiseReceiveDto>();
        }

        public async Task<List<DropdownListDto1>> GetProcessNameList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_ProcessNameDDL";

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

        public async Task<List<DropdownListDto1>> GetMachineNoList()
        {
            List<DropdownListDto1> list = new List<DropdownListDto1>();
            DynamicParameters parameter = new DynamicParameters();
            string query = "sp_Get_MachineNoDDL";

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

        public async Task<Result> SaveWashBatchPrepareData(
            SaveWashBatchPrepareModel dto)
        {
            if (dto == null)
                return Result.Failure(new[] { "Request data is null" });

            // 🔥 Convert SizeDetails → DataTable (TVP)
            var sizeTable = new DataTable();
            sizeTable.Columns.Add("SizeId", typeof(int));
            sizeTable.Columns.Add("Size", typeof(string));
            sizeTable.Columns.Add("Qty", typeof(int));
            sizeTable.Columns.Add("Kg", typeof(decimal));

            foreach (var s in dto.SizeDetails)
            {
                sizeTable.Rows.Add(
                    s.sizeId,
                    s.size,
                    s.qty,
                    s.kg
                );
            }

            var param = new DynamicParameters();

            // ===== MASTER =====
            param.Add("@Operation", dto.Master.operation);
            param.Add("@CreatedBy", _currentUserService?.EmployeeId ?? "SYSTEM");
            //param.Add("@CreatedBy", dto.Master.createdBy);
            param.Add("@MasterId", dto.Master.masterId);
            param.Add("@UnitId", dto.Master.unitId);
            param.Add("@TrackingNo", dto.Master.trackingNo);
            param.Add("@BatchNo", dto.Master.batchNo);
            param.Add("@DocumentNo", dto.Master.documentNo);
            param.Add("@EffectiveDate", dto.Master.effectiveDate);
            param.Add("@RevisionDate", dto.Master.revisionDate);
            param.Add("@RevisionNo", dto.Master.revisionNo);
            param.Add("@Date", dto.Master.date);

            param.Add("@BuyerId", dto.Master.buyerId);
            param.Add("@JobId", dto.Master.jobId);
            param.Add("@StyleId", dto.Master.styleId);
            param.Add("@OrderId", dto.Master.orderId);
            param.Add("@FabricationId", dto.Master.fabricationId);
            param.Add("@ColorId", dto.Master.colorId);
            param.Add("@DressPartId", dto.Master.dressPartId);
            param.Add("@UomId", dto.Master.uomId);
            param.Add("@IszId", dto.Master.iszId);

            param.Add("@ProcessIds", dto.Master.processIds);
            param.Add("@MachineIds", dto.Master.machineIds);
            param.Add("@TotalPcs", dto.Master.totalKg);
            param.Add("@TotalKg", dto.Master.totalPcs);
            param.Add("@Type", dto.Master.type);

            // ===== TVP =====
            param.Add(
                "@SizeDetails",
                sizeTable.AsTableValuedParameter("dbo.TVP_WashPrepare_Size")
            );

            try
            {
                using var conn = CreateConnection();

                var result = await conn.QueryFirstOrDefaultAsync<SaveWashBatchResponse>(
                  "[dbo].[sp_SaveWashBatchPrepare]",
                  param,
                  commandType: CommandType.StoredProcedure
              );

                return Result.Success(result.AutoBatchNo);
            }
            catch (SqlException ex)
            {
                return Result.Failure(new[] { ex.Message });
            }
        }
        public class SaveWashBatchResponse
        {
            public int ResultCode { get; set; }
            public int MasterId { get; set; }
            public string AutoBatchNo { get; set; }
        }

        public async Task<List<TrackingNoWiseReceiveDto>> GetWashItemDeliveryList(
    int unitId,
    string fromDate,
    string toDate,
    string trackingBatchNo)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UnitId", unitId, DbType.Int32);


            parameter.Add("@FromDate",
                string.IsNullOrWhiteSpace(fromDate) ? null : fromDate,
                DbType.String);

            parameter.Add("@ToDate",
                string.IsNullOrWhiteSpace(toDate) ? null : toDate,
                DbType.String);

            parameter.Add("@TrackingBatchNo",
            string.IsNullOrWhiteSpace(trackingBatchNo) ? null : trackingBatchNo,
            DbType.String);
            const string spName = "[dbo].[SP_GetDataForDeliveryBatchItem]";

            var result = await GetDisposeErrorFreeListAsyncNew<TrackingNoWiseReceiveDto>(
               spName,
               parameter
           );

            return result?.ToList() ?? new List<TrackingNoWiseReceiveDto>();
        }



        public async Task<Result> SaveWashItemDeliveryData(
            SaveWashItemDeliveryModel dto)
        {
            if (dto == null)
                return Result.Failure(new[] { "Request data is null" });

            // 🔥 Convert SizeDetails → DataTable (TVP)
            var sizeTable = new DataTable();
            sizeTable.Columns.Add("SizeId", typeof(int));
            sizeTable.Columns.Add("Size", typeof(string));
            sizeTable.Columns.Add("Qty", typeof(int));
            sizeTable.Columns.Add("Kg", typeof(decimal));


            foreach (var s in dto.SizeDetails)
            {
                sizeTable.Rows.Add(
                    s.sizeId,
                    s.size,
                    s.qty,
                    s.kg
                );
            }

            var param = new DynamicParameters();

            // ===== MASTER =====
            param.Add("@Operation", dto.Master.operation);
            param.Add("@CreatedBy", _currentUserService?.EmployeeId ?? "SYSTEM");
            //param.Add("@CreatedBy", dto.Master.createdBy);
            param.Add("@MasterId", dto.Master.masterId);
            param.Add("@UnitId", dto.Master.unitId);
            param.Add("@TrackingNo", dto.Master.trackingNo);
            param.Add("@BuyerId", dto.Master.buyerId);
            param.Add("@JobId", dto.Master.jobId);
            param.Add("@StyleId", dto.Master.styleId);
            param.Add("@OrderId", dto.Master.orderId);
            param.Add("@FabricationId", dto.Master.fabricationId);
            param.Add("@ColorId", dto.Master.colorId);
            param.Add("@DressPartId", dto.Master.dressPartId);
            param.Add("@UomId", dto.Master.uomId);
            param.Add("@IszId", dto.Master.iszId);
            param.Add("@TotalPcs", dto.Master.totalKg);
            param.Add("@Type", dto.Master.type);

            // ===== TVP =====
            param.Add(
                "@SizeDetails",
                sizeTable.AsTableValuedParameter("dbo.TVP_WashPrepare_Size")
            );

            try
            {
                using var conn = CreateConnection();

                await conn.ExecuteAsync(
                    "[dbo].[sp_SaveWashItemDeliveryData]",
                    param,
                    commandType: CommandType.StoredProcedure
                );

                return Result.Success("Saved successfully");
            }
            catch (SqlException ex)
            {
                return Result.Failure(new[] { ex.Message });
            }
        }


        public async Task<List<GetFaultWiseListDto>> GetFaultWiseListDataList(
   int inspectionTypeId, int inspectionHeadId, int faultHeadId)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@InspectionTypeId", inspectionTypeId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@InspectionHeadId", inspectionHeadId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@FaultHeadId", faultHeadId, DbType.Int32, ParameterDirection.Input);


           
            const string spName = "[dbo].[SP_GetFaultNameAndValueByTypeInspectionHeadAndFaultHeade]";

            var result = await GetDisposeErrorFreeListAsyncNew<GetFaultWiseListDto>(
               spName,
               parameter
           );

            return result?.ToList() ?? new List<GetFaultWiseListDto>();
        }



        public async Task<Result> SaveFaultWiseValueData(SaveFaultWiseValueModel dto)
        {
            if (dto == null)
                return Result.Failure(new[] { "Request data is null" });

            if (dto.Details == null || !dto.Details.Any())
                return Result.Failure(new[] { "No detail data found" });

            try
            {
                // ============================
                // Convert List → DataTable (TVP)
                // ============================

                var table = new DataTable();

                table.Columns.Add("FaultNameId", typeof(int));
                table.Columns.Add("FaultValue", typeof(decimal));
                table.Columns.Add("IsActive", typeof(bool));

                foreach (var item in dto.Details)
                {
                    table.Rows.Add(
                        item.FaultNameId,
                        item.FaultValue,
                        item.IsActive
                    );
                }

                // ============================
                // Parameters
                // ============================

                var parameter = new DynamicParameters();

                parameter.Add("@InspectionTypeId", dto.InspectionTypeId);
                parameter.Add("@InspectionHeadId", dto.InspectionHeadId);
                parameter.Add("@FaultHeadId", dto.FaultHeadId);

                parameter.Add("@CreatedBy",
                    string.IsNullOrEmpty(dto.CreatedBy)
                        ? _currentUserService?.EmployeeId ?? "SYSTEM"
                        : dto.CreatedBy);

                parameter.Add(
                    "@Details",
                    table.AsTableValuedParameter("dbo.FaultWiseValueTagType")
                );

                // ============================
                // Execute SP
                // ============================

                using var conn = CreateConnection();

                int affectedRows = await conn.ExecuteAsync(
                    "dbo.SP_SaveFaultWiseValueTag",
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                return affectedRows >= 0
                    ? Result.Success("Saved successfully")
                    : Result.Failure(new[] { "No rows affected" });
            }
            catch (SqlException ex)
            {
                return Result.Failure(new[] { $"Database error: {ex.Message}" });
            }
            catch (Exception ex)
            {
                return Result.Failure(new[] { $"Unexpected error: {ex.Message}" });
            }
        }


        public async Task<List<GetBatchPriorityDto>> GetPrioritySetDataList(int unitId, string date)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UnitId", unitId, DbType.Int32, ParameterDirection.Input); 
            parameter.Add("@Date", date, DbType.String, ParameterDirection.Input);


            const string spName = "[dbo].[SP_GetBatchwisePrioritySetData]";

            var result = await GetDisposeErrorFreeListAsyncNew<GetBatchPriorityDto>(
               spName,
               parameter
           );

            return result?.ToList() ?? new List<GetBatchPriorityDto>();
        }



        //public async Task<Result> SaveBatchPriorityBulk(SaveBatchPriorityModel dto)
        //{
        //    if (dto == null || dto.Rows == null || !dto.Rows.Any())
        //        return Result.Failure(new[] { "Request data is null or empty" });

        //    try
        //    {
        //        // ============================
        //        // Convert List → DataTable (TVP)
        //        // ============================
        //        var table = new DataTable();
        //        table.Columns.Add("BatchNo", typeof(string));
        //        table.Columns.Add("UnitId", typeof(int));
        //        table.Columns.Add("Date", typeof(DateTime));
        //        table.Columns.Add("MachineId", typeof(int));
        //        table.Columns.Add("Priority", typeof(int));
        //        table.Columns.Add("Qty", typeof(decimal));
        //        table.Columns.Add("BuyerId", typeof(int));
        //        table.Columns.Add("JobId", typeof(int));
        //        table.Columns.Add("StyleId", typeof(int));
        //        table.Columns.Add("OrderId", typeof(int));
        //        table.Columns.Add("ColorId", typeof(int));

        //        foreach (var item in dto.Rows)
        //        {
        //            table.Rows.Add(
        //                item.BatchNo,
        //                item.UnitId,
        //                item.Date,
        //                item.MachineId,
        //                item.Priority,
        //                item.Qty,
        //                item.BuyerId,
        //                item.JobId,
        //                item.StyleId,
        //                item.OrderId,
        //                item.ColorId
        //            );
        //        }

        //        // ============================
        //        // Parameters
        //        // ============================
        //        var parameter = new DynamicParameters();
        //        // Use a single CreatedBy from first row if not null, otherwise SYSTEM
        //        var createdBy = dto.Rows.FirstOrDefault()?.CreatedBy ?? _currentUserService?.EmployeeId ?? "SYSTEM";
        //        parameter.Add("@CreatedBy", createdBy);

        //        parameter.Add("@Details", table.AsTableValuedParameter("dbo.tbl_BatchPriority_TVP"));

        //        // ============================
        //        // Execute SP
        //        // ============================
        //        using var conn = CreateConnection();

        //        int affectedRows = await conn.ExecuteAsync(
        //            "dbo.sp_Save_BatchPriorityData",
        //            parameter,
        //            commandType: CommandType.StoredProcedure
        //        );

        //        return affectedRows > 0
        //            ? Result.Success("Saved successfully")
        //            : Result.Failure(new[] { "No rows affected" });
        //    }
        //    catch (SqlException ex)
        //    {
        //        return Result.Failure(new[] { $"Database error: {ex.Message}" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result.Failure(new[] { $"Unexpected error: {ex.Message}" });
        //    }
        //}
        public async Task<WrapperResponseBatchPriority> SaveBatchPriorityBulk(SaveBatchPriorityModel dto)
        {
            var response = new WrapperResponseBatchPriority();

            if (dto == null || dto.Rows == null || !dto.Rows.Any())
            {
                response.IsSuccess = false;
                response.Message = "Request data is null or empty";
                return response;
            }

            try
            {
                // ============================
                // Convert List → DataTable (TVP)
                // ============================
                var table = new DataTable();
                table.Columns.Add("UnitId", typeof(int));
                table.Columns.Add("BatchNo", typeof(string));
               
               // table.Columns.Add("Date", typeof(DateTime));
                table.Columns.Add("MachineId", typeof(int));
                
               
                table.Columns.Add("BuyerId", typeof(int));
                table.Columns.Add("JobId", typeof(int));
                table.Columns.Add("StyleId", typeof(int));
                table.Columns.Add("OrderId", typeof(int));
                table.Columns.Add("ColorId", typeof(int));
                table.Columns.Add("Priority", typeof(int));
                table.Columns.Add("Qty", typeof(decimal));
                table.Columns.Add("Date", typeof(DateTime));
                foreach (var item in dto.Rows)
                {
                    table.Rows.Add(
                        item.UnitId,
                        item.BatchNo,
                        
                       // item.Date,
                        item.MachineId,
                       
                        item.BuyerId,
                        item.JobId,
                        item.StyleId,
                        item.OrderId,
                        item.ColorId,
                         item.Priority,
                        item.Qty,
                        item.Date
                    );
                }

                // ============================
                // Parameters
                // ============================
                var parameter = new DynamicParameters();
                var createdBy = dto.Rows.FirstOrDefault()?.CreatedBy ?? _currentUserService?.EmployeeId ?? "SYSTEM";
                parameter.Add("@CreatedBy", createdBy);
                parameter.Add("@Details", table.AsTableValuedParameter("dbo.tbl_BatchPriority_TVP"));

                // ============================
                // Execute SP
                // ============================
                using var conn = CreateConnection();
                int affectedRows = await conn.ExecuteAsync(
                    "dbo.sp_Save_WashBatchPriority",
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                response.IsSuccess = affectedRows > 0;
                response.ResultCode = affectedRows > 0 ? "1" : "0";
                response.Message = affectedRows > 0 ? "Saved successfully" : "No rows affected";

                return response;
            }
            catch (SqlException ex)
            {
                response.IsSuccess = false;
                response.Message = $"Database error: {ex.Message}";
                response.ResultCode = "0";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Unexpected error: {ex.Message}";
                response.ResultCode = "0";
                return response;
            }
        }


        public async Task<List<BatchWishQCDataDto>> GetBatchWishQCDataList( string batchNo)
        {
            var parameter = new DynamicParameters();

         
            parameter.Add("@BatchNo", batchNo, DbType.String, ParameterDirection.Input);


            const string spName = "[dbo].[tbl_SP_Get_BatchWiseQCData]";

            var result = await GetDisposeErrorFreeListAsyncNew<BatchWishQCDataDto>(
               spName,
               parameter
           );

            return result?.ToList() ?? new List<BatchWishQCDataDto>();
        }




        public async Task<WrapperResponseQCData> SaveQcData(SaveQCDataModel dto)
        {
            var response = new WrapperResponseQCData();

            // ============================
            // 🔥 VALIDATION
            // ============================
            if (dto == null || dto.Master == null)
            {
                response.IsSuccess = false;
                response.Message = "Request data is null or invalid";
                return response;
            }

            try
            {
                // ============================
                // 🔥 REPAIRABLE TABLE (TVP)
                // ============================
                var repairableTable = new DataTable();
                repairableTable.Columns.Add("DefectId", typeof(int));
                repairableTable.Columns.Add("Qty", typeof(int));
                

                foreach (var item in dto.RepairableDetails)
                {
                    repairableTable.Rows.Add(
                        item.DefectId,
                        item.Qty
                      
                    );
                }

                // ============================
                // 🔥 REJECT TABLE (TVP)
                // ============================
                var rejectTable = new DataTable();
                rejectTable.Columns.Add("DefectId", typeof(int));
                rejectTable.Columns.Add("Qty", typeof(int));
               

                foreach (var item in dto.RejectDetails)
                {
                    rejectTable.Rows.Add(
                        item.DefectId,
                        item.Qty
                     
                    );
                }

                // ============================
                // 🔥 PARAMETERS
                // ============================
                var parameter = new DynamicParameters();

                var createdBy = dto.Master.CreatedBy
                                ?? _currentUserService?.EmployeeId
                                ?? "SYSTEM";

                parameter.Add("@CreatedBy", createdBy);

                // 🔥 MASTER PARAMS
                parameter.Add("@UnitId", dto.Master.UnitId);
                parameter.Add("@BuyerId", dto.Master.BuyerId);
                parameter.Add("@StyleId", dto.Master.StyleId);
                parameter.Add("@OrderId", dto.Master.OrderId);
                parameter.Add("@JobId", dto.Master.JobId);
                parameter.Add("@DressPartId", dto.Master.DressPartId);
                parameter.Add("@UomId", dto.Master.UomId);

                parameter.Add("@BatchNo", dto.Master.BatchNo);
                parameter.Add("@Type", dto.Master.Type);
                parameter.Add("@Color", dto.Master.Color);
                parameter.Add("@Date", dto.Master.Date);

                parameter.Add("@GoodGarments", dto.Master.GoodGarments);
                parameter.Add("@RepairableQty", dto.Master.Repairable);
                parameter.Add("@RejectQty", dto.Master.Reject);

                // 🔥 TVP
                parameter.Add("@RepairableDetails", repairableTable.AsTableValuedParameter("dbo.tbl_QCDetail_TVP"));
                parameter.Add("@RejectDetails", rejectTable.AsTableValuedParameter("dbo.tbl_QCDetail_TVP"));

                // ============================
                // 🔥 EXECUTE SP
                // ============================
                using var conn = CreateConnection();

                int affectedRows = await conn.ExecuteAsync(
                    "dbo.sp_Save_QCData",
                    parameter,
                    commandType: CommandType.StoredProcedure
                );

                response.IsSuccess = affectedRows > 0;
                response.ResultCode = affectedRows > 0 ? "1" : "0";
                response.Message = affectedRows > 0 ? "Saved successfully" : "No rows affected";

                return response;
            }
            catch (SqlException ex)
            {
                response.IsSuccess = false;
                response.Message = $"Database error: {ex.Message}";
                response.ResultCode = "0";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Unexpected error: {ex.Message}";
                response.ResultCode = "0";
                return response;
            }
        }


    }


}





