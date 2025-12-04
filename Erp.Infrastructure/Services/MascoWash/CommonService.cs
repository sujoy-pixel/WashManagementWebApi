using Dapper;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Auth.RoleManagement.Command;
using Erp.Application.Common.Interfaces;
using Erp.Application.MascoWash.Queries;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using Erp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Services.MascoWash
{
   
    public class CommonService : DbContext<DropdownListDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISetupService _setupService;

        public CommonService(ICurrentUserService currentUserService, IConfiguration configuration, ApplicationDbContext dbcontext) : base(configuration)
        {
            _dbContext = dbcontext;
            _currentUserService = currentUserService;

        }
    }
}
