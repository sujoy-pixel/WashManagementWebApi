//using Erp.Application.Requests.ErpApp.External_API_Factory.Command;
//using Erp.Application.Requests.ErpApp.External_API_Factory.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erp.WebApi.Controllers.External_API_Factory
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmployeeAPIFromFactoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeAPIFromFactoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //[ActionName("GetEmployeeInfoByEmployeeId")]
        //public async Task<IActionResult> GetAllGatePassUserListBySupervisor(string employeeId)
        //{
        //    return Ok(await _mediator.Send(new EmployeeInfoByEmployeeId { employeeId = employeeId }));
        //}
        //[HttpGet]
        //[ActionName("GetEmployeeInfoByUnit")]
        //public async Task<IActionResult> GetEmployeeInfoByUnit(string unit)
        //{
        //    return Ok(await _mediator.Send(new GetEmployeeInfoByUnit { Unit = unit }));
        //}

        //[HttpPost]
        //[ActionName("EmployeeSync")]
        //public async Task<IActionResult> EmployeeSync(EmployeeSync command)
        //{

        //    var result = await _mediator.Send(command);

        //    if (result.Succeeded)
        //        return Ok(result);

        //    return BadRequest(result.Errors);
        //}

        //[HttpPost]
        //[ActionName("TaxableEmployeeSync")]
        //public async Task<IActionResult> TaxableEmployeeSync(TaxableEmployeeSync command)
        //{

        //    var result = await _mediator.Send(command);

        //    if (result.Succeeded)
        //        return Ok(result);

        //    return BadRequest(result.Errors);
        //}

        //[HttpPost]
        //[ActionName("LocalSupplierSync")]
        //public async Task<IActionResult> LocalSupplierSync(LocalSupplierSync command)
        //{

        //    var result = await _mediator.Send(command);

        //    if (result.Succeeded)
        //        return Ok(result);

        //    return BadRequest(result.Errors);
        //}



    }
}
