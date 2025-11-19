//using AutoMapper;
//using Erp.Application.Common.Interfaces;
////using Erp.Application.Requests.ErpApp.External_API_Factory;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Erp.Application.Auth.Commands
//{
//    public class SignInFromSaraHandler : IRequestHandler<SIgnInFromSara, object>
//    {
//        private readonly IIdentityService _identityService;
//        private readonly IMapper _mapper;
//        //private readonly IEmployeeFromAPI _saraEmployeeFromApi;

//        //public SignInFromSaraHandler(IIdentityService identityService, IMapper mapper, IEmployeeFromAPI saraEmployeeFromApi)
//                public SignInFromSaraHandler(IIdentityService identityService, IMapper mapper)
//        {
//            _identityService = identityService;
//            _mapper = mapper;
//            //_saraEmployeeFromApi = saraEmployeeFromApi;
//        }
//        public async Task<object> Handle(SIgnInFromSara request, CancellationToken cancellationToken)
//        {
//            //var saraEmpList = await _saraEmployeeFromApi.GetSaRaEmployeeListAll();
//           // var saraEmpList = await _saraEmployeeFromApi.GetSaRaEmployeeListAll();
//           // var findEmployeeId = saraEmpList.Find(e => e.EmployeeID == request.EmployeeId);
//            //if (findEmployeeId != null)
//            //{
//            //    var obj = new UserForLoginDto
//            //    {
//            //        UserName = request.EmployeeId
//            //    };

//            //    return await _identityService.SignInFromSara(obj);
//            //}
//            //else
//            //{
//            //    throw new UnauthorizedAccessException("User not found!");
//            //}





//        }
//    }
//}
