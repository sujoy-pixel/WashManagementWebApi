using Erp.Application.Auth.RoleManagement;
using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Commercial.Setup
{
    public interface ISetup
    {
        Task<List<DropdownListDto>> GetReportName(string ReportMenu,string UserId);
    }
}
