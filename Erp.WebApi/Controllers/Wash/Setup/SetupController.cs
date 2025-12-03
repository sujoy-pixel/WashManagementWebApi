using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using Erp.Application.Commercial.Setup.Command;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Erp.WebApi.Controllers.Commercial.Setup
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SetupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //public SalaryService _salaryService { get; set; }
        public SetupController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            this._webHostEnvironment = webHostEnvironment;
            //this._salaryService = salaryService;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

                                              /// Process Name Entry ///

        [HttpPost]
        [ActionName("SaveProcessNameEntry")]
        public async Task<IActionResult> SaveProcessNameEntry(saveProcessNameData command)
        {
           
            return Ok(await _mediator.Send(command));

        }

        [HttpGet]
        [ActionName("GetProcessNameEntryData")]
        public async Task<IActionResult> GetProcessNameEntryData()
        {
            return Ok(await _mediator.Send(new ProcessNameEntryGet()));
        }

                                                  /// Operation Name Entry ///

        [HttpPost]
        [ActionName("SaveOperationNameEntry")]
        public async Task<IActionResult> SaveOperationNameEntry(saveOperationNameData command)
        {

            return Ok(await _mediator.Send(command));

        }

        [HttpGet]
        [ActionName("GetOperationNameEntryData")]
        public async Task<IActionResult> GetOperationNameEntryData()
        {
            return Ok(await _mediator.Send(new OperationNameEntryGet()));
        }

                                                  /// Type of Inspection ///

        [HttpPost]
        [ActionName("SaveTypeofInspection")]
        public async Task<IActionResult> SaveTypeofInspection(saveTypeofInspectionData command)
        {

            return Ok(await _mediator.Send(command));

        }

        [HttpGet]
        [ActionName("GetTypeofInspectionData")]
        public async Task<IActionResult> GetTypeofInspectionData()
        {
            return Ok(await _mediator.Send(new TypeofInspectionGet()));
        }
    }
}
