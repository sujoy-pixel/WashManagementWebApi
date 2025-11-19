using Erp.Application.Auth.Commands;
using Erp.Application.Auth.RoleManagement.Query;
using Erp.Application.Commercial.Command;
using Erp.Application.Commercial.Setup.Command;
using Erp.Application.Requests.ErpApp.SCHOOL.User.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erp.WebApi.Controllers.Commercial.Menu
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ActionName("GetMenuList")]
        public async Task<IActionResult> GetMenuALL()
        {
            return Ok(await _mediator.Send(new MenuList()));
        }
        [HttpGet]
        [ActionName("GetMenusByUserId")]
        public async Task<IActionResult> GetMenusByUserId(int UserId)
        {
            return Ok(await _mediator.Send(new GetMenusByUserId(UserId)));
        }
        //================Test basis list of data save

        [HttpPost]
        [ActionName("SaveListOfData")]
        public async Task<IActionResult> SaveListOfData(SaveDataList command)
        {
            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors);
        }

    }
}
