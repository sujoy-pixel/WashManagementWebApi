using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Erp.Application.Auth.Commands;
using Erp.Application.Auth.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Erp.WebApi.SingleLogin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnotherAppsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnotherAppsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostRegisteredUser(PostRegisteredUser command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetRandomToken(string empCode, string tokenNumber)
        {
            return Ok(await _mediator.Send(new GetRandomToken(empCode, tokenNumber)));
        }

    }
}
