using System.Threading.Tasks;
using Erp.Application.Auth.Commands;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Erp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
    
        public async Task<IActionResult> Login(LoginUser command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("SingleSignIn")]
        public async Task<IActionResult> SignleLogin(SingleSignIn command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        //[AllowAnonymous]
        //[HttpPost("SigninFromSara")]
        //public async Task<IActionResult> SigninFromSara(SIgnInFromSara command)
        //{
        //    var result = await _mediator.Send(command);

        //    return Ok(result);
        //}



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser command)
        {

            var result = await _mediator.Send(command);

            if (result.Succeeded)
                return StatusCode(201);

            return BadRequest(result.Errors);
        }



        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUser(id));

            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordForAdmin command)
        {
            var result = await _mediator.Send(command);

            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Errors);
        }

    }
}