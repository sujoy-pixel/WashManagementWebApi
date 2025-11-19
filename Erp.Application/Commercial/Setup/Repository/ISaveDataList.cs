using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using Erp.Domain.Entities.Commercial.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Commercial.Setup.Repository
{
    public interface ISaveDataList
    {
        Task<Result> CreateDataList(SaveDataListDto saveDataListDto);
    }
}
