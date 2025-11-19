using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.Commercial.Setup
{
    public interface ISetupService
    {
        Task<Result> CreateUserList(UserRollDto UserRollDto);
    }
}
