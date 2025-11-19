

using Erp.Application.Commercial.Setup.Command;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erp.WebApi.Controllers.Commercial.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

    }
}
