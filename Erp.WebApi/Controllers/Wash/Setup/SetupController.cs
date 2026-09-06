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
        public async Task<IActionResult> getSearchDataForEdit(
      int unitId,
      string? receiveNo,
      string? fromDate,
      string? toDate)
        {
            var result = await _mediator.Send(
                new GetDataBySearchForEdit(unitId, receiveNo, fromDate, toDate)
            );

            return Ok(result);
        }
        [ActionName("GetWashBatchPrepareGrid")]
        public async Task<IActionResult> GetWashBatchPrepareGridData(int unitId, int buyerId, int jobId, int styleId, int orderId)
        {
            var result = await _mediator.Send(
                new GetWashBatchPrepareGridQuery(unitId, buyerId, jobId, styleId, orderId)
            );

            return Ok(result);
        }
        [HttpGet]
        [ActionName("getWashBatchPrepareGridEdit")]
        public async Task<IActionResult> getWashBatchPrepareGridEditData(int unitId, int buyerId, int jobId, int styleId, int orderId)
        {
            var result = await _mediator.Send(
                new BatchPrepareEditQuery(unitId, buyerId, jobId, styleId, orderId)
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
        public async Task<IActionResult> SaveWashItemDelivery(SaveWashItemDeliveryModel command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet]
        [ActionName("getFaultWiseList")]
        public async Task<IActionResult> GetFaultWiseListData(int inspectionTypeId, int inspectionHeadId, int faultHeadId)
        {
            var result = await _mediator.Send(
                new GetFaultWiseListDataQuery(inspectionTypeId, inspectionHeadId, faultHeadId)
            );

            return Ok(result);
        }

        [HttpPost]

        [ActionName("SaveFaultWiseValue")]
        public async Task<IActionResult> SaveFaultWiseValue(
    [FromBody] SaveFaultWiseValueModel command)
        {
            return Ok(await _mediator.Send(command));
        }



        [HttpGet]
        [ActionName("getBatchPriorityList")]
        public async Task<IActionResult> GetBatchPriorityListData(int unitId, string date)
        {
            var result = await _mediator.Send(
                new GetBatchPriorityDataQuery(unitId, date)
            );

            return Ok(result);
        }
        [HttpPost]
        [ActionName("SaveBatchPriorityBulk")]
        public async Task<IActionResult> SaveBatchPriorityData(SaveBatchPriorityModel command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet]
        [ActionName("getBatchWishQCDataList")]
        public async Task<IActionResult> BatchWishQCData(string batchNo)
        {
            var result = await _mediator.Send(
                new BatchWishQCDataQuery(batchNo)
            );

            return Ok(result);
        }
        //[HttpPost("SaveQCData")]
        //public async Task<IActionResult> SaveQCData([FromBody] SaveQCDataModel command)
        //{
        //    if (command == null)
        //        return BadRequest(new { isSuccess = false, message = "Payload is NULL — JSON binding failed" });

        //    if (command.Master == null)
        //        return BadRequest(new { isSuccess = false, message = "Master is NULL — check property name casing" });

        //    var result = await _mediator.Send(command);

        //    return Ok(result);
        //}

        [HttpPost]
        [ActionName("SaveQCData")]
        public async Task<IActionResult> SaveQCDataModel(SaveQCDataModel command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet]
        [ActionName("getBatchWishStartEndData")]
        public async Task<IActionResult> BatchWishStartEndData(string batchNo)
        {
            var result = await _mediator.Send(
                new BatchWiseStartEndDataQuery(batchNo)
            );

            return Ok(result);
        }
        [HttpGet]
        [ActionName("getBatchWishAsidPrepareData")]
        public async Task<IActionResult> getBatchWishAsidPrepareData(string batchNo)
        {
            var result = await _mediator.Send(
                new getBatchWishAsidPrepareDataDataQuery(batchNo)
            );

            return Ok(result);
        }


        [HttpGet]
        [ActionName("getBatchWishShadeData")]
        public async Task<IActionResult> GetgetBatchWishShadeData(string batchNo)
        {
            var result = await _mediator.Send(
                new BathchWiseShadeDataQuery(batchNo)
            );

            return Ok(result);
        }
        [HttpGet]
        [ActionName("getStartEndOperationData")]
        public async Task<IActionResult> StartEndOperationData(string batchNo)
        {
            var result = await _mediator.Send(
                new BatchStartEndOperationQuery(batchNo)
            );

            return Ok(result);
        }


        [HttpPost]
        [ActionName("SaveWashStartEndData")]
        public async Task<IActionResult> SaveWashStartEnd(SaveWashStartEndModel command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        [ActionName("SaveBatchWiseShadeStatus")]
        public async Task<IActionResult> SaveBatchWiseShadeStatusData(SaveBatchWiseShadeStatusModel command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("SaveAcidWashBatchPrepare")]
        public async Task<IActionResult> SaveAcidWashBatchPrepare(
        [FromBody] SaveAcidWashBatchPrepareCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [ActionName("GetBatchNoDDL")]
        public async Task<IActionResult> GetBatchNo(string itemText)
        {
            return Ok(await _mediator.Send(new BatchNoAutoCompleteDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetBatchNoQCAutoComplete")]
        public async Task<IActionResult> GetBatchNoQCAutoComplete(string searchText)
        {
            return Ok(
                await _mediator.Send(
                    new BatchNoQCAutoCompleteQuery(searchText)
                )
            );
        }



        [HttpPost]
        public async Task<IActionResult> GetBatchNoByDateAndShift(
            [FromBody] GetBatchNoByDateAndShiftQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ActionName("getFloorStatusData")]
        public async Task<IActionResult> GetFloorStatusData(
    [FromBody] FloorStatusRequestDto objparam)
        {
            if (objparam == null)
                return BadRequest("Invalid request.");

            var result = await _mediator.Send(
                new FloorStatusQuery(
                    objparam.UnitId,
                    objparam.FromDate,
                    objparam.ToDate,
                    objparam.OrderType
                )
            );

            return Ok(result);
        }

        [HttpPost]
        [ActionName("getDateWiseQcPassDhuData")]
        public async Task<IActionResult> GetDateWiseQCPassDHUDashboard(
    [FromBody] DateWiseQCPassDHUDashboardRequestDto objparam)
        {
            if (objparam == null)
                return BadRequest("Invalid request.");

            var result = await _mediator.Send(
                new DateWiseQCPassDHUDashboardQuery(
                    objparam.UnitId,
                    objparam.FromDate,
                    objparam.ToDate
                )
            );

            return Ok(result);
        }


        [HttpPost]
        [ActionName("getStyleWiseQcPassDhuData")]
        public async Task<IActionResult> GetStyleWiseQCPassDHUDashboard(
         [FromBody] StyleWiseQCPassDHUDashboardRequestDto objparam)
        {
            if (objparam == null)
                return BadRequest("Invalid request.");

            var result = await _mediator.Send(
                new StyleWiseQCPassDHUDashboardQuery(
                    objparam.UnitId,
                    objparam.FromDate,
                    objparam.ToDate
                )
            );

            return Ok(result);
        }





        [HttpPost]
        [ActionName("getStyleWiseRejectionData")]
        public async Task<IActionResult> GetStyleWiseRejectionData(
           [FromBody] StyleWiseRejectionRequestDto objparam)
        {
            if (objparam == null)
                return BadRequest("Invalid request.");

            if (objparam.UnitId <= 0)
                return BadRequest("UnitId is required.");

            if (objparam.BuyerId <= 0)
                return BadRequest("BuyerId is required.");

            if (objparam.FromDate == default || objparam.ToDate == default)
                return BadRequest("FromDate and ToDate are required.");

            if (objparam.FromDate > objparam.ToDate)
                return BadRequest("FromDate cannot be after ToDate.");

            var result = await _mediator.Send(
                new StyleWiseRejectionQuery(
                    objparam.UnitId,
                    objparam.BuyerId,
                    objparam.FromDate,
                    objparam.ToDate
                )
            );

            return Ok(result);
        }

        // NOTE: The Angular UI calls getStyleWiseRejectionSizes() in
        // onBuyerChange() to pre-load the size headers BEFORE the user
        // picks a date range and clicks View. Two ways to implement:
        //
        //   (A) Reuse SP_Get_StyleWiseRejectionData with a wide date
        //       range and grab the column names from the first row's
        //       SizeRejects dictionary keys. Simple but heavy.
        //
        //   (B) Add a dedicated lightweight SP that returns just the
        //       distinct size list for this buyer. Recommended.
        //
        // Below uses approach (A) so you don't have to add a new SP
        // right now - but consider migrating to (B) once the dashboard
        // is stable.
        [HttpPost]
        [ActionName("getStyleWiseRejectionSizes")]
        public async Task<IActionResult> GetStyleWiseRejectionSizes(
            [FromBody] StyleWiseRejectionSizesRequestDto objparam)
        {
            if (objparam == null)
                return BadRequest("Invalid request.");

            if (objparam.UnitId <= 0 || objparam.BuyerId <= 0)
                return BadRequest("UnitId and BuyerId are required.");

            // Use a wide 5-year window so every size the buyer has ever
            // been recorded against in QC_SizeDetails shows up as a
            // column. The SP derives its size column list from the
            // buyer's full QC_SizeDetails history, NOT the date range,
            // so the window is only here to ensure the SP returns at
            // least one row whose SizeRejects dictionary we can read.
            var fromDate = new System.DateTime(2020, 1, 1);
            var toDate = System.DateTime.Today.AddYears(1);

            var result = await _mediator.Send(
                new StyleWiseRejectionQuery(
                    objparam.UnitId,
                    objparam.BuyerId,
                    fromDate,
                    toDate
                )
            );

            // Build the distinct union of size column names across all
            // returned rows. The column list is stable across date
            // ranges (the SP's @SizeList is built without a date
            // filter), so even one row is enough - but union across
            // all rows in case the SP is later changed to filter
            // sizes by date range.
            var sizeNames = new System.Collections.Generic.List<string>();

            if (result != null && result.Count > 0)
            {
                var seen = new System.Collections.Generic.HashSet<string>();
                foreach (var row in result)
                {
                    if (row.SizeRejects == null) continue;
                    foreach (var size in row.SizeRejects.Keys)
                    {
                        if (string.IsNullOrWhiteSpace(size)) continue;
                        if (seen.Add(size))
                            sizeNames.Add(size);
                    }
                }
            }

            // Project to a small { size, label } payload that matches
            // what the Angular service expects (see WashSetupService.
            // getStyleWiseRejectionSizes).
            var payload = sizeNames
                .Select(s => new { size = s, label = s })
                .ToList();

            return Ok(payload);
        }

        [HttpPost]
        [ActionName("getDateWiseRejectionData")]
        public async Task<IActionResult> GetDateWiseRejectionData(
           [FromBody] DateWiseRejectionRequestDto objparam)
        {
            if (objparam == null)
                return BadRequest("Invalid request.");

            if (objparam.UnitId <= 0)
                return BadRequest("UnitId is required.");

            if (objparam.BuyerId <= 0)
                return BadRequest("BuyerId is required.");

            if (objparam.FromDate == default || objparam.ToDate == default)
                return BadRequest("FromDate and ToDate are required.");

            if (objparam.FromDate > objparam.ToDate)
                return BadRequest("FromDate cannot be after ToDate.");

            var result = await _mediator.Send(
                new DateWiseRejectionQuery(
                    objparam.UnitId,
                    objparam.BuyerId,
                    objparam.FromDate,
                    objparam.ToDate
                )
            );

            return Ok(result);
        }

        // NOTE: The Angular UI calls getStyleWiseRejectionSizes() in
        // onBuyerChange() to pre-load the size headers BEFORE the user
        // picks a date range and clicks View. Two ways to implement:
        //
        //   (A) Reuse SP_Get_StyleWiseRejectionData with a wide date
        //       range and grab the column names from the first row's
        //       SizeRejects dictionary keys. Simple but heavy.
        //
        //   (B) Add a dedicated lightweight SP that returns just the
        //       distinct size list for this buyer. Recommended.
        //
        // Below uses approach (A) so you don't have to add a new SP
        // right now - but consider migrating to (B) once the dashboard
        // is stable.
        [HttpPost]
        [ActionName("getDateWiseRejectionSizes")]
        public async Task<IActionResult> GetDateWiseRejectionSizes(
            [FromBody] DateWiseRejectionSizesRequestDto objparam)
        {
            if (objparam == null)
                return BadRequest("Invalid request.");

            if (objparam.UnitId <= 0 || objparam.BuyerId <= 0)
                return BadRequest("UnitId and BuyerId are required.");

            // Use a wide 5-year window so every size the buyer has ever
            // been recorded against in QC_SizeDetails shows up as a
            // column. The SP derives its size column list from the
            // buyer's full QC_SizeDetails history, NOT the date range,
            // so the window is only here to ensure the SP returns at
            // least one row whose SizeRejects dictionary we can read.
            var fromDate = new System.DateTime(2020, 1, 1);
            var toDate = System.DateTime.Today.AddYears(1);

            var result = await _mediator.Send(
                new StyleWiseRejectionQuery(
                    objparam.UnitId,
                    objparam.BuyerId,
                    fromDate,
                    toDate
                )
            );

            // Build the distinct union of size column names across all
            // returned rows. The column list is stable across date
            // ranges (the SP's @SizeList is built without a date
            // filter), so even one row is enough - but union across
            // all rows in case the SP is later changed to filter
            // sizes by date range.
            var sizeNames = new System.Collections.Generic.List<string>();

            if (result != null && result.Count > 0)
            {
                var seen = new System.Collections.Generic.HashSet<string>();
                foreach (var row in result)
                {
                    if (row.SizeRejects == null) continue;
                    foreach (var size in row.SizeRejects.Keys)
                    {
                        if (string.IsNullOrWhiteSpace(size)) continue;
                        if (seen.Add(size))
                            sizeNames.Add(size);
                    }
                }
            }

            // Project to a small { size, label } payload that matches
            // what the Angular service expects (see WashSetupService.
            // getStyleWiseRejectionSizes).
            var payload = sizeNames
                .Select(s => new { size = s, label = s })
                .ToList();

            return Ok(payload);
        }

        [HttpPost]
        [ActionName("getDateWiseBalanceData")]
        public async Task<IActionResult> GetDateWiseBalanceDashboard(
  [FromBody] DateWiseBalanceDashboardRequestDto objparam)
        {
            if (objparam == null) return BadRequest("Invalid request.");
            if (objparam.UnitId <= 0) return BadRequest("UnitId is required.");
            if (objparam.ViewType != 1 && objparam.ViewType != 2)
                return BadRequest("ViewType must be 1 (Garments) or 2 (Fabric & Cutting Parts).");

            var result = await _mediator.Send(
                new DateWiseBalanceDashboardQuery(
                    objparam.UnitId,
                    objparam.FromDate,
                    objparam.ToDate,
                    objparam.ViewType));

            return Ok(result);
        }


        [HttpPost]
        [ActionName("getOrderWiseBalanceData")]
        public async Task<IActionResult> GetOrderWiseBalanceDashboard(
  [FromBody] OrderWiseBalanceDashboardRequestDto objparam)
        {
            if (objparam == null) return BadRequest("Invalid request.");
            if (objparam.UnitId <= 0) return BadRequest("UnitId is required.");
            if (objparam.ViewType != 1 && objparam.ViewType != 2)
                return BadRequest("ViewType must be 1 (Garments) or 2 (Fabric & Cutting Parts).");

            var result = await _mediator.Send(
                new OrderWiseBalanceDashboardQuery(
                    objparam.UnitId,
                    objparam.FromDate,
                    objparam.ToDate,
                    objparam.ViewType));

            return Ok(result);
        }
    }
}


