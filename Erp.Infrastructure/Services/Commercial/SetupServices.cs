using Castle.Core;
using Dapper;
using Erp.Application.Auth.RoleManagement;

using Erp.Application.Commercial.Setup;
using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Commercial.Setup.Repository;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
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

namespace Erp.Infrastructure.Services.Commercial
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
