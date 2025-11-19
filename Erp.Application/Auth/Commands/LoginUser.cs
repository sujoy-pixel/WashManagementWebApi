using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using MediatR;

namespace Erp.Application.Auth.Commands
{
    public class LoginUser : IRequest<List<UserCreateDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
       // public int BranchOfficeId { get; set; }
       // public int FinYearId { get; set; }

    }
}
