using AutoMapper;
using Erp.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.External_API_Factory.Query
{
    public class GetEmployeeInfoByUnitHandler : IRequestHandler<GetEmployeeInfoByUnit, List<APIEmployeeInfoDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IEmployeeFromAPI _employeeFromAPI;
        public GetEmployeeInfoByUnitHandler(ICurrentUserService currentUserService, IMapper mapper, IEmployeeFromAPI employeeFromAPI)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _employeeFromAPI = employeeFromAPI;
        }
        public async Task<List<APIEmployeeInfoDto>> Handle(GetEmployeeInfoByUnit request, CancellationToken cancellationToken)
        {
            var list = await _employeeFromAPI.EmployeeDataByUnit(request.Unit);

            return _mapper.Map<List<APIEmployeeInfoDto>>(list);
        }
    }
}
