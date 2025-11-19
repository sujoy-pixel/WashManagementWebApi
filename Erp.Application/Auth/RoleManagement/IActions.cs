using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement
{
    public interface IActions
    {
        Task<List<ActionsDto>> GetAllActions();
    }
}
