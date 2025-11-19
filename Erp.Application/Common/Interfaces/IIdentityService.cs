using System.Threading.Tasks;
using Erp.Application.Common.Models;
using Erp.Application.Auth;
using System.Collections.Generic;
using Erp.Application.Auth.Commands;
using System;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Requests.ErpApp.SCHOOL.User;

namespace Erp.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<object> Login(UserForLoginDto userForLogin);
     
       // Task<(Result Result, int UserId)> Register(UserForRegisterDto userForRegister);
        Task<Result> DeleteUser(int id);
     
        Task<List<UserCreateDto>> LoginNew(UserForLoginDto userForLogin);
    }
}
