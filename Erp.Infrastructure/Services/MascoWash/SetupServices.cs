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



        //public async Task<List<machineDetailModel>> SaveMachineName(SaveMachineName saveDataListDto)
        //{

        //    List<machineDetailModel> list = new List<machineDetailModel>();
        //    List<machineDetailModel> listDetail = saveDataListDto._listData.ToList();
        //    DataTable dataTable = ListToDataTableConversion.ConvertListToDataTable(listDetail);
        //    DynamicParameters parameterMaster = new DynamicParameters();
        //    DynamicParameters parameter = new DynamicParameters();
        //    string queryMasterFile = "sp_Generate_MasterLcFileNo";
        //    parameterMaster.Add("@UnitId", saveDataListDto.UnitId, DbType.Int32, ParameterDirection.Input);

        //    //string query = "sp_Insert_Update_MasterLc_Master_Detail_Cursor_1";
        //    string query = "sp_Insert_Update_MasterLc_Master_Detail_Cursor_1_test";
        //    parameter.Add("@TableParam", dataTable.AsTableValuedParameter());
        //    //parameter.Add("@MasterLcId", saveDataListDto.MasterLcId, DbType.Int32, ParameterDirection.Input);
        //    //parameter.Add("@MasterLcType", saveDataListDto.MasterLcType, DbType.String, ParameterDirection.Input);
        //    //parameter.Add("@AmendmentDate", saveDataListDto.AmendmentDate, DbType.String, ParameterDirection.Input);

        //    //parameter.Add("@MasterLcFileNo", masterLcFileNo, DbType.String, ParameterDirection.Input);
        //    //parameter.Add("@UnitId", saveDataListDto.UnitId, DbType.Int32, ParameterDirection.Input);
        //    //parameter.Add("@BuyerId", saveDataListDto.BuyerId, DbType.Int32, ParameterDirection.Input);
        //    //parameter.Add("@Udno", saveDataListDto.UDNo, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@CreatedBy", _currentUserService.EmployeeId, DbType.String, ParameterDirection.Input);
        //    parameter.Add("@ClientIpAddress", _currentUserService.IpAddress, DbType.String, ParameterDirection.Input);

        //    //====================Execute
        //    var GetList = await GetDataByDataTable<SaveListModel>(query, parameter, dataTable);

        //    return list;
        //}

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

    }
}


