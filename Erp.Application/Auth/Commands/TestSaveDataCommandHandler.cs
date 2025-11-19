using AutoMapper;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.Commercial.Setup;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.Commands
{
    public class TestSaveDataCommandHandler : IRequestHandler<TestSaveDataCommand, Result>
    {
        private readonly ICreateMenuPermission _setupservice;
        public TestSaveDataCommandHandler(ICreateMenuPermission setupService)
        {
            _setupservice = setupService;
        }
        public async Task<Result> Handle(TestSaveDataCommand request, CancellationToken cancellationToken)
        {
            var result = Result.Success();
            foreach (var item in request.UserRoleList)
            {
                UserRollDto userRoleDto = new UserRollDto
                {
                    School_Name_Id = request.School_Name_Id,
                    School_Branch_Id = request.School_Branch_Id
                };
                result = await _setupservice.CreateUserList(userRoleDto);

            }
            return result;
        }
    }
}
