using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using Erp.Application.Commercial.Setup.Command;
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


    }
}
