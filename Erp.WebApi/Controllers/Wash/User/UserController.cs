
using Erp.Application.Auth.RoleManagement.Query;

using Erp.Application.Requests.ErpApp.SCHOOL.User;
using Erp.Application.Requests.ErpApp.SCHOOL.User.Command;
using Erp.Application.Requests.ErpApp.SCHOOL.User.Query;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erp.WebApi.Controllers.SCHOOL.User
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMediator _mediator;
        private object request;
        private object httpContext;
        private readonly IHttpContextAccessor _context;
        public UserController(IMediator mediator, IWebHostEnvironment hostingEnvironment)
        {
            _mediator = mediator;
            _hostingEnvironment = hostingEnvironment;
        }
      




       
   

        #region
        [HttpPost]
        [ActionName("SaveUserCreate")]
        public async Task<IActionResult> SaveUserCreate(NewUserCreate command)
        {
            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors);
        }
    
    
     
        #endregion

        #region Menu Permission
        //[HttpGet]
        //[ActionName("GetMenuList")]
        //public async Task<IActionResult> GetMenuALL()
        //{
        //    return Ok(await _mediator.Send(new MenuList()));
        //}
        //[HttpGet]
        //[ActionName("GetMenusByUserId")]
        //public async Task<IActionResult> GetMenusByUserId()
        //{
        //    return Ok(await _mediator.Send(new Application.Requests.ErpApp.SCHOOL.User.Query.GetMenusByUserId()));
        //}
        [HttpGet]
        [ActionName("GetMenusByUserId")]
        public async Task<IActionResult> GetMenusByUserId(int Id,int Id1,int Id2)
        {
            return Ok(await _mediator.Send(new Application.Requests.ErpApp.SCHOOL.User.Query.GetMenusByUserId { Id = Id, Id1 = Id1,Id2=Id2 }));
        }
     
     

        [HttpPost]
     
        [HttpGet]
        [ActionName("GetParentMenu")]
        public async Task<IActionResult> GetParentMenu()
        {
            return Ok(await _mediator.Send(new NewParentMenuList { }));
        }
        [HttpGet]
        [ActionName("GetMenuCreateList")]
        public async Task<IActionResult> GetMenuCreateList()
        {
            return Ok(await _mediator.Send(new NewMenuCreateList { }));
        }

        [HttpPost]
        [ActionName("SaveMenuCreate")]
        public async Task<IActionResult> SaveMenuCreate(NewMenuCreateSave command)
        {

            var result = await _mediator.Send(command);

            if (result.Succeeded)
                return StatusCode(201);

            return BadRequest(result.Errors);
        }


        #endregion
        #region payment amount
        [HttpPost]
        [ActionName("SavePaymentAmount")]
        public async Task<IActionResult> SavePaymentAmount(NewPaymentAmount command)
        {
            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors);
        }


        #endregion
    }
}
