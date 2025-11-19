using Dapper;
using Erp.Application.Auth.RoleManagement.Command;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Common.Interfaces;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using Erp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Net.NetworkInformation;
using MediatR;
using System.ComponentModel.Design;

namespace Erp.Infrastructure.Services.Commercial
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
