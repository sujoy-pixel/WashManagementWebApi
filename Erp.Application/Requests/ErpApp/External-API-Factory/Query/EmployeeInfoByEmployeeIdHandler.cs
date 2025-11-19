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
    public class EmployeeInfoByEmployeeIdHandler : IRequestHandler<EmployeeInfoByEmployeeId, List<APIEmployeeInfoDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IEmployeeFromAPI _employeeFromAPI;
        public EmployeeInfoByEmployeeIdHandler(ICurrentUserService currentUserService, IMapper mapper, IEmployeeFromAPI employeeFromAPI)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _employeeFromAPI = employeeFromAPI;
        }

        public async Task<List<APIEmployeeInfoDto>> Handle(EmployeeInfoByEmployeeId request, CancellationToken cancellationToken)
        {
            var list = await _employeeFromAPI.EmployeeData(request.employeeId);

            return _mapper.Map<List<APIEmployeeInfoDto>>(list);
        }
    }
}
