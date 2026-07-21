using AspNetCore.Reporting;
using Dapper;
using Erp.Infrastructure.Services.MascoWash;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Erp.WebApi.Controllers.MascoWash.Report
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ReportService _service;

        public ReportController(
            IMediator mediator,
            IWebHostEnvironment webHostEnvironment,
            ReportService service)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _service = service;

            System.Text.Encoding.RegisterProvider(
                System.Text.CodePagesEncodingProvider.Instance);
        }

        #region MAIN REPORT API

        [HttpPost]
        [ActionName("ShowReport")]
        public async Task<IActionResult> Report([FromBody] Model objparam)
        {
            try
            {
                if (objparam == null)
                    return BadRequest("Invalid request.");

                string reportName = objparam.ReportName?.Trim();
                if (string.IsNullOrWhiteSpace(reportName))
                    return BadRequest("ReportName is required.");

                string reportType = objparam.Type?.Trim().ToUpper() ?? "PDF";

                string cleanName = Regex.Replace(reportName, @"\s+", "");

                string query = _service.GetStoredProcedure(reportName);

                var param = new DynamicParameters();

                byte[] qrBytes = null;

                // ==============================
                // SPECIAL CASE: QR GENERATION
                // ==============================
                if (reportName == "Batch Card Preview")
                {
                    string trackingNo = objparam.GenerateNumber ?? "";

                    param.Add("@TrackingNo", trackingNo, DbType.String, ParameterDirection.Input);

                    qrBytes = GenerateQrCode(trackingNo);
                }
                //if (reportName == "Date Wise Hourly QC Report")
                //{
                //    // validate mandatory filters
                //    if (!objparam.UnitId.HasValue || !objparam.BuyerId.HasValue || !objparam.StyleId.HasValue || !objparam.Date.HasValue)
                //        return BadRequest("UnitId, BuyerId, StyleId and Date are required for Date Wise Hourly QC Report.");
                //    param.Add("@UnitId", objparam.UnitId, DbType.Int32, ParameterDirection.Input);
                //    param.Add("@BuyerId", objparam.BuyerId, DbType.Int32, ParameterDirection.Input);
                //    param.Add("@StyleId", objparam.StyleId, DbType.Int32, ParameterDirection.Input);
                //    param.Add("@Date", objparam.Date, DbType.Date, ParameterDirection.Input);
                //    param.Add("@OrderId", objparam.OrderId, DbType.Int32, ParameterDirection.Input); // nullable
                //    param.Add("@JobId", objparam.JobId, DbType.Int32, ParameterDirection.Input); // nullable
                //    param.Add("@BatchNo", objparam.BatchNo, DbType.String, ParameterDirection.Input); // nullable
                //    param.Add("@ShiftId", objparam.ShiftId, DbType.Int32, ParameterDirection.Input); // nullable
                //}

                // ==============================
                // GET DATA FROM DB
                // ==============================


                DataTable dt = await _service.GetDataByDataTable(query, param);

                if (dt == null || dt.Rows.Count == 0)
                    return BadRequest("No data available for the report.");

                // ==============================
                // ADD QR COLUMN (IMPORTANT FIX)
                // ==============================
                if (qrBytes != null)
                {
                    if (!dt.Columns.Contains("QrCode"))
                        dt.Columns.Add("QrCode", typeof(byte[]));
                    DataTable cloneTable = dt.Clone(); // copy structure

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = cloneTable.NewRow();

                        foreach (DataColumn col in dt.Columns)
                        {
                            newRow[col.ColumnName] = row[col.ColumnName];
                        }

                        newRow["QrCode"] = qrBytes;

                        cloneTable.Rows.Add(newRow);
                    }

                    dt = cloneTable;
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    row["QrCode"] = qrBytes;
                    //    dt.Rows.Add
                    //}
                }


                // ==============================
                // LOAD RDLC FILE
                // ==============================
                string rdlcPath = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "Reports",
                    $"{cleanName}.rdlc"
                );

                if (!System.IO.File.Exists(rdlcPath))
                    return NotFound("RDLC file not found.");

                var localReport = new LocalReport(rdlcPath);

                string datasetName = "ds" + cleanName;
                localReport.AddDataSource(datasetName, dt);

                // ==============================
                // PARAMETERS
                // ==============================
                var parameters = new Dictionary<string, string>();

                if (reportName == "Batch Card Preview")
                {
                    parameters.Add("ReportHeader", reportName);
                }
                if (reportName == "Date Wise Hourly QC Report")
                {
                    parameters.Add("ReportHeader", reportName);
                }

                // ==============================
                // RENDER REPORT
                // ==============================
                RenderType renderType =
                    reportType == "PDF"
                        ? RenderType.Pdf
                        : RenderType.ExcelOpenXml;

                var result = localReport.Execute(renderType, 1, parameters, "");

                string fileName = reportType == "PDF"
                    ? $"{cleanName}.pdf"
                    : $"{cleanName}.xlsx";

                string mimeType = reportType == "PDF"
                    ? "application/pdf"
                    : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "reports", fileName);

                if (reportType == "PDF")
                {
                    System.IO.File.WriteAllBytes(filePath, result.MainStream);

                    string url =
                        $"{Request.Scheme}://{Request.Host}/reports/{fileName}?t={DateTime.Now.Ticks}";

                    return Ok(new { url });
                }

                return File(result.MainStream, mimeType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ActionName("ShowReportMultiResult")]
        public async Task<IActionResult> ReportMultiResult([FromBody] Model objparam)
        {
            try
            {
                if (objparam == null)
                    return BadRequest("Invalid request.");

                string originalReportName = objparam.ReportName?.Trim();

                if (string.IsNullOrWhiteSpace(originalReportName))
                    return BadRequest("ReportName is required.");

                string reportType = objparam.Type?.Trim().ToUpper() ?? "PDF";

                //==============================================
                // Determine RDLC based on Shift
                //==============================================
                string rdlcReportName = originalReportName;

                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    if (!objparam.ShiftId.HasValue)
                        return BadRequest("Shift is required.");

                    rdlcReportName = objparam.ShiftId == 1
                        ? "DateWiseHourlyQCReportMShift"
                        : "DateWiseHourlyQCReport";
                }

                string cleanName = Regex.Replace(rdlcReportName, @"\s+", "");

                // Always use the original report name to fetch SP
                string query = _service.GetStoredProcedure(originalReportName);

                var param = new DynamicParameters();

                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    if (!objparam.UnitId.HasValue ||
                        !objparam.BuyerId.HasValue ||
                        !objparam.StyleId.HasValue ||
                        !objparam.Date.HasValue)
                    {
                        return BadRequest("UnitId, BuyerId, StyleId and Date are required.");
                    }

                    param.Add("@UnitId", objparam.UnitId, DbType.Int32, ParameterDirection.Input);
                    param.Add("@BuyerId", objparam.BuyerId, DbType.Int32, ParameterDirection.Input);
                    param.Add("@StyleId", objparam.StyleId, DbType.Int32, ParameterDirection.Input);
                    param.Add("@Date", objparam.Date, DbType.Date, ParameterDirection.Input);
                    param.Add("@OrderId", objparam.OrderId, DbType.Int32, ParameterDirection.Input);
                    param.Add("@JobId", objparam.JobId, DbType.Int32, ParameterDirection.Input);
                    param.Add("@BatchNo", objparam.BatchNo, DbType.String, ParameterDirection.Input);
                    param.Add("@ShiftId", objparam.ShiftId, DbType.Int32, ParameterDirection.Input);
                }

                //==============================================
                // Load RDLC
                //==============================================
                string rdlcPath = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "Reports",
                    $"{cleanName}.rdlc"
                );

                if (!System.IO.File.Exists(rdlcPath))
                    return NotFound($"RDLC file '{cleanName}.rdlc' not found.");

                var localReport = new LocalReport(rdlcPath);

                //==============================================
                // Load Data
                //==============================================
                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    DataSet ds = await _service.ExecuteStoredProcedureToDataSetAsync(query, param);

                    localReport.AddDataSource("dsDateWiseHourlyQCReport", ds.Tables[0]);
                    localReport.AddDataSource("dsDateWiseHourlyQCReportSummary", ds.Tables[1]);
                }

                //==============================================
                // Parameters
                //==============================================
                var parameters = new Dictionary<string, string>();

                //if (originalReportName == "Date Wise Hourly QC Report")
                //{

                //    parameters.Add("ReportHeader", originalReportName);
                //}
                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    parameters.Add("ReportHeader", "Hourly QC Pass & DHU Report");
                }
                //==============================================
                // Render Report
                //==============================================
                RenderType renderType = reportType == "PDF"
                    ? RenderType.Pdf
                    : RenderType.ExcelOpenXml;

                var result = localReport.Execute(renderType, 1, parameters, "");

                string fileName = reportType == "PDF"
                    ? $"{cleanName}.pdf"
                    : $"{cleanName}.xlsx";

                string mimeType = reportType == "PDF"
                    ? "application/pdf"
                    : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "reports", fileName);

                if (reportType == "PDF")
                {
                    System.IO.File.WriteAllBytes(filePath, result.MainStream);

                    string url = $"{Request.Scheme}://{Request.Host}/reports/{fileName}?t={DateTime.Now.Ticks}";

                    return Ok(new { url });
                }

                return File(result.MainStream, mimeType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpPost]
        //[ActionName("ShowReportMultiResult")]
        //public async Task<IActionResult> ReportMultiResult([FromBody] Model objparam)
        //{
        //    try
        //    {
        //        if (objparam == null)
        //            return BadRequest("Invalid request.");

        //        string reportName = objparam.ReportName?.Trim();
        //        if (string.IsNullOrWhiteSpace(reportName))
        //            return BadRequest("ReportName is required.");

        //        string reportType = objparam.Type?.Trim().ToUpper() ?? "PDF";

        //        string cleanName = Regex.Replace(reportName, @"\s+", "");

        //        string query = _service.GetStoredProcedure(reportName);

        //        var param = new DynamicParameters();

        //        byte[] qrBytes = null;

        //        // ==============================
        //        // SPECIAL CASE: QR GENERATION
        //        // ==============================

        //        if (reportName == "Date Wise Hourly QC Report")
        //        {
        //            // validate mandatory filters
        //            if (!objparam.UnitId.HasValue || !objparam.BuyerId.HasValue || !objparam.StyleId.HasValue || !objparam.Date.HasValue)
        //                return BadRequest("UnitId, BuyerId, StyleId and Date are required for Date Wise Hourly QC Report.");
        //            param.Add("@UnitId", objparam.UnitId, DbType.Int32, ParameterDirection.Input);
        //            param.Add("@BuyerId", objparam.BuyerId, DbType.Int32, ParameterDirection.Input);
        //            param.Add("@StyleId", objparam.StyleId, DbType.Int32, ParameterDirection.Input);
        //            param.Add("@Date", objparam.Date, DbType.Date, ParameterDirection.Input);
        //            param.Add("@OrderId", objparam.OrderId, DbType.Int32, ParameterDirection.Input); // nullable
        //            param.Add("@JobId", objparam.JobId, DbType.Int32, ParameterDirection.Input); // nullable
        //            param.Add("@BatchNo", objparam.BatchNo, DbType.String, ParameterDirection.Input); // nullable
        //            param.Add("@ShiftId", objparam.ShiftId, DbType.Int32, ParameterDirection.Input); // nullable
        //        }

        //        // ==============================
        //        // GET DATA FROM DB
        //        // ==============================
        //        string rdlcPath = Path.Combine(
        //            _webHostEnvironment.WebRootPath,
        //            "Reports",
        //            $"{cleanName}.rdlc"
        //        );
        //        var localReport = new LocalReport(rdlcPath);
        //        if (reportName == "Date Wise Hourly QC Report")
        //        {
        //            DataSet ds = await _service.ExecuteStoredProcedureToDataSetAsync(query, param);
        //            DataTable dt1 = ds.Tables[0];
        //            DataTable dt2 = ds.Tables[1];
        //            localReport.AddDataSource("dsDateWiseHourlyQCReport", dt1);
        //            localReport.AddDataSource("dsDateWiseHourlyQCReportSummary", dt2);


        //        }


        //        // ==============================
        //        // LOAD RDLC FILE
        //        // ==============================


        //        if (!System.IO.File.Exists(rdlcPath))
        //            return NotFound("RDLC file not found.");



        //        // ==============================
        //        // PARAMETERS
        //        // ==============================
        //        var parameters = new Dictionary<string, string>();
        //        if (reportName == "Date Wise Hourly QC Report")
        //        {
        //            parameters.Add("ReportHeader", reportName);
        //        }

        //        // ==============================
        //        // RENDER REPORT
        //        // ==============================
        //        RenderType renderType =
        //            reportType == "PDF"
        //                ? RenderType.Pdf
        //                : RenderType.ExcelOpenXml;

        //        var result = localReport.Execute(renderType, 1, parameters, "");

        //        string fileName = reportType == "PDF"
        //            ? $"{cleanName}.pdf"
        //            : $"{cleanName}.xlsx";

        //        string mimeType = reportType == "PDF"
        //            ? "application/pdf"
        //            : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "reports", fileName);

        //        if (reportType == "PDF")
        //        {
        //            System.IO.File.WriteAllBytes(filePath, result.MainStream);

        //            string url =
        //                $"{Request.Scheme}://{Request.Host}/reports/{fileName}?t={DateTime.Now.Ticks}";

        //            return Ok(new { url });
        //        }

        //        return File(result.MainStream, mimeType, fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        #endregion

        #region QR GENERATOR (FIXED)

        private byte[] GenerateQrCode(string text)
        {
            using var generator = new QRCodeGenerator();
            using var data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

            // ✅ BEST FOR .NET 6 (NO System.Drawing ISSUE)
            var qrCode = new PngByteQRCode(data);
            return qrCode.GetGraphic(20);
        }

        #endregion

        #region MODEL

        public class Model
        {
            public string? ReportName { get; set; }
            public string? Type { get; set; }
            public string? GenerateNumber { get; set; }
            public int? UnitId { get; set; }
            public int? BuyerId { get; set; }
            public int? StyleId { get; set; }
            public DateTime? Date { get; set; }
            public int? OrderId { get; set; }
            public int? JobId { get; set; }
            public string? BatchNo { get; set; }
            public int? ShiftId { get; set; }
        }

        #endregion
    }
}