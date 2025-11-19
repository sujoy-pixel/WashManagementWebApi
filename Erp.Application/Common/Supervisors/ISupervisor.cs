using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Common.Supervisors
{
   public interface ISupervisor
    {
        Task<List<SupervisorInfoDto>> GetSupervisorListFromEmployeeId();
        Task<List<SupervisorInfoDto>> GetSupervisorPersonalInfo();


    }
}
