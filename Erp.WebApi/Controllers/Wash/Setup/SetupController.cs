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

                                                    /// Inspection Area ///
                                                   
        [HttpPost]
        [ActionName("SaveInspectionArea")]
        public async Task<IActionResult> SaveInspectionArea(saveInspectionAreaData command)
        {

            return Ok(await _mediator.Send(command));

        }

        [HttpGet]
        [ActionName("GetInspectionAreaData")]
        public async Task<IActionResult> GetInspectionAreaData()
        
        {
            return Ok(await _mediator.Send(new InspectionAreaGet()));
        }


                                                 /// Fault Head Name Layout ///

        [HttpPost]
        [ActionName("SaveFaultHead")]
        public async Task<IActionResult> SaveFaultHead(saveFaultHeadData command)
        {

            return Ok(await _mediator.Send(command));

        }

        [HttpGet]
        [ActionName("GetFaultHeadData")]
        public async Task<IActionResult> GetFaultHeadData()
        {
            return Ok(await _mediator.Send(new FaultHeadGet()));
        }

                                                 /// Inspection Head Layout ///

        [HttpPost]
        [ActionName("SaveInspectionHead")]
        public async Task<IActionResult> SaveInspectionHead(saveInspectionHeadData command)
        {

            return Ok(await _mediator.Send(command));

        }

        [HttpGet]
        [ActionName("GetInspectionHeadData")]
        public async Task<IActionResult> GetInspectionHeadData()
        {
            return Ok(await _mediator.Send(new InspectionHeadGet()));
        }


                                                     /// Fault Name Layout ///

        [HttpPost]
        [ActionName("SaveFaultName")]
        public async Task<IActionResult> SaveFaultName(saveFaultNameData command)
        {

            return Ok(await _mediator.Send(command));

        }

        [HttpGet]
        [ActionName("GetFaultNameData")]
        public async Task<IActionResult> GetFaultNameData()
        {
            return Ok(await _mediator.Send(new FaultNameGet()));
        }

        //[HttpPost]
        //[ActionName("SaveMachineMasterDetailEntry")]
        //public async Task<IActionResult> SaveMachineMasterDetailEntry([FromBody] SaveMachineName dto)
        //{
        //    // You can map dto to a mediator command that will transform MachineList -> DataTable and call the SP.
        //    return Ok(await _mediator.Send(new SaveMachineMasterDetailCommand(dto)));
        //}



        [HttpPost]
        [ActionName("SaveMachineName")]
        public async Task<IActionResult> SaveMachineName(SaveMachineName command)
        {
            return Ok(await _mediator.Send(command));
        }


        //[HttpPost]
        //[ActionName("SaveMachineName")]
        //public async Task<IActionResult> SaveMachineName(SaveMachineName command)
        //{
        //    var result = await _mediator.Send(command);
        //    if (result.Succeeded)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Errors);
        //}





        [HttpPost]
        [ActionName("CheckMachineExists")]
        public async Task<IActionResult> CheckMachineExists(CheckMachineExistsDto dto)
        {
            return Ok(await _mediator.Send(
                new CheckMachineExistsQuery(dto.UnitId, dto.OperationId, dto.MachineName)
            ));
        }

        [HttpGet]
        [ActionName("GetMachineMasterList")]
        public async Task<IActionResult> GetMachineMasterList()
        {
            return Ok(await _mediator.Send(new GetMachineMasterListQuery()));
        }


                                                     /// Fault Wise Name Tag ///
        [HttpPost]
        [ActionName("SaveFaultWiseValueTag")]
        public async Task<IActionResult> SaveFaultWiseValueTag(saveFaultWiseValueTagData command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [ActionName("GetFaultWiseValueTagData")]
        public async Task<IActionResult> GetFaultWiseValueTagData()
        {
            return Ok(await _mediator.Send(new FaultWiseValueTagGet()));
        }


        [HttpGet]
        [ActionName("GetFaultWiseValueTagDataByMasterId")]
        public async Task<IActionResult> GetFaultWiseValueTagDataByMasterId(int FaultWiseMasterId)
        {
            return Ok(await _mediator.Send(new FaultWiseValueTagGetByMasterId(FaultWiseMasterId)));
        }

        [HttpGet]
        [ActionName("GetReceiveByTrackingNo")]
        public async Task<IActionResult> GetReceiveByTrackingNo(string trackingNo)
        {
            var result = await _mediator.Send(
                new GetReceiveByTrackingNoQuery(trackingNo)
            );

            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetReceiveByBatchNo")]
        public async Task<IActionResult> GetReceiveByBatchNo(string batchNo)
        {
            var result = await _mediator.Send(
                new GetReceiveByBatchNoQuery(batchNo)
            );

            return Ok(result);
        }

        [HttpPost]
        [ActionName("SaveTrackingNoReceive")]
        public async Task<IActionResult> SaveTrackingNoReceive(SaveTrackingNoReceive command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        [ActionName("getSearchDataByReceiveNoOrDate")]
        public async Task<IActionResult> getSearchDataForEdit(int unitId, string receiveNo , string fromDate , string toDate )
        {
            var result = await _mediator.Send(
                new GetDataBySearchForEdit(unitId, receiveNo, fromDate, toDate)
            );

            return Ok(result);
        }

        [ActionName("GetWashBatchPrepareGrid")]
        public async Task<IActionResult> GetWashBatchPrepareGridData(int unitId,int buyerId,int jobId,int styleId, int orderId)
        {
            var result = await _mediator.Send(
                new GetWashBatchPrepareGridQuery(unitId, buyerId, jobId, styleId, orderId)
            );

            return Ok(result);
        }

        [HttpPost]
        [ActionName("SaveWashBatchPrepare")]
        public async Task<IActionResult> SaveWashBatchPrepare(SaveWashBatchPrepareModel command)
        {
            return Ok(await _mediator.Send(command));
        }

        [ActionName("GetWashItemDeliveryList")]
        public async Task<IActionResult> GetWashItemDeliveryListOfData(int unitId, string fromDate, string toDate, string trackingBatchNo)
        {
            var result = await _mediator.Send(
                new GetWashItemDeliveryListQuery(unitId, fromDate, toDate, trackingBatchNo)
            );

            return Ok(result);
        }


        [HttpPost]
        [ActionName("SaveWashItemDelivery")]
        public async Task<IActionResult>SaveWashItemDelivery(SaveWashItemDeliveryModel command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
