

using Erp.Application.Commercial.Setup.Command;
using Erp.Application.MascoWash.Queries;
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

        [HttpGet]
        [ActionName("GetUnitName")]
        public async Task<IActionResult> GetUnitName()
        {
            return Ok(await _mediator.Send(new UnitNameGet()));
        }
       

        [HttpGet]
        [ActionName("GetFaultHead")]
        public async Task<IActionResult> GetFaultHead()
        {
            return Ok(await _mediator.Send(new FaultHeadDDL()));
        }

        [HttpGet]
        [ActionName("GetInspectionHeadDDL")]
        public async Task<IActionResult> GetInspectionHeadDDL()
        {
            return Ok(await _mediator.Send(new InspectionHeadDDL()));
        }

        [HttpGet]
        [ActionName("GetOperationNameDDL")]
        public async Task<IActionResult> GetOperationNameDDL()
        {
            return Ok(await _mediator.Send(new OperationNameDDL()));
        }
    }
}
