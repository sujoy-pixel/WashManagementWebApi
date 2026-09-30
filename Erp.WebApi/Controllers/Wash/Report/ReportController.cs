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
using System.Linq;
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
                if (reportName == "Batch Card Preview" || reportName == "Batch Card Preview Dublicate")
                {
                    string trackingNo = objparam.GenerateNumber ?? "";

                    param.Add("@TrackingNo", trackingNo, DbType.String, ParameterDirection.Input);

                    // the V3 card prints the QR without the white margin so it fills its box like the design
                    qrBytes = GenerateQrCode(trackingNo, reportName != "Batch Card Preview Dublicate");
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

                // Design V3 layout reads fixed columns (Size1..15, P1..P4); RDLC expressions can't be compiled on .NET Core
                if (reportName == "Batch Card Preview Dublicate")
                    dt = FlattenBatchCardV3(dt);


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

                if (reportName == "Batch Card Preview" || reportName == "Batch Card Preview Dublicate")
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
        //public async Task<IActionResult> ReportMultiResult([FromBody] Model objparam)
        //{
        //    try
        //    {
        //        if (objparam == null)
        //            return BadRequest("Invalid request.");

        //        string originalReportName = objparam.ReportName?.Trim();

        //        if (string.IsNullOrWhiteSpace(originalReportName))
        //            return BadRequest("ReportName is required.");

        //        string reportType = objparam.Type?.Trim().ToUpper() ?? "PDF";

        //        //==============================================
        //        // Determine RDLC based on Shift
        //        //==============================================
        //        string rdlcReportName = originalReportName;

        //        if (originalReportName == "Date Wise Hourly QC Report")
        //        {
        //            if (!objparam.ShiftId.HasValue)
        //                return BadRequest("Shift is required.");

        //            rdlcReportName = objparam.ShiftId == 1
        //                ? "DateWiseHourlyQCReportMShift"
        //                : "DateWiseHourlyQCReport";
        //        }

        //        string cleanName = Regex.Replace(rdlcReportName, @"\s+", "");

        //        // Always use the original report name to fetch SP
        //        string query = _service.GetStoredProcedure(originalReportName);

        //        var param = new DynamicParameters();

        //        //if (originalReportName == "Date Wise Hourly QC Report")
        //        //{
        //        //    if (!objparam.UnitId.HasValue ||
        //        //        !objparam.BuyerId.HasValue ||
        //        //        !objparam.StyleId.HasValue ||
        //        //        !objparam.Date.HasValue)
        //        //    {
        //        //        return BadRequest("UnitId, BuyerId, StyleId and Date are required.");
        //        //    }

        //        //    param.Add("@UnitId", objparam.UnitId, DbType.Int32, ParameterDirection.Input);
        //        //    param.Add("@BuyerId", objparam.BuyerId, DbType.Int32, ParameterDirection.Input);
        //        //    param.Add("@StyleId", objparam.StyleId, DbType.Int32, ParameterDirection.Input);
        //        //    param.Add("@Date", objparam.Date, DbType.Date, ParameterDirection.Input);
        //        //    param.Add("@OrderId", objparam.OrderId, DbType.Int32, ParameterDirection.Input);
        //        //    param.Add("@JobId", objparam.JobId, DbType.Int32, ParameterDirection.Input);
        //        //    param.Add("@BatchNo", objparam.BatchNo, DbType.String, ParameterDirection.Input);
        //        //    param.Add("@ShiftId", objparam.ShiftId, DbType.Int32, ParameterDirection.Input);
        //        //}
        //        if (originalReportName == "Date Wise Hourly QC Report")
        //        {
        //            bool hasBatchNo =
        //                !string.IsNullOrWhiteSpace(objparam.BatchNo);

        //            // ============================================
        //            // Batch No mode
        //            // ============================================
        //            if (hasBatchNo)
        //            {
        //                // Batch No is enough.
        //                // No other field is mandatory.
        //            }
        //            else
        //            {
        //                // ============================================
        //                // Normal filter mode
        //                // ============================================
        //                if (!objparam.UnitId.HasValue ||
        //                    !objparam.BuyerId.HasValue ||
        //                    !objparam.JobId.HasValue ||
        //                    !objparam.StyleId.HasValue ||
        //                    !objparam.OrderId.HasValue ||
        //                    !objparam.Date.HasValue ||
        //                    !objparam.ShiftId.HasValue)
        //                {
        //                    return BadRequest(
        //                        "Unit, Buyer, Job, Style, Order, Shift and Date are required when Batch No is not selected."
        //                    );
        //                }
        //            }

        //            // ============================================
        //            // Add parameters
        //            // ============================================

        //            param.Add(
        //                "@UnitId",
        //                hasBatchNo ? null : objparam.UnitId,
        //                DbType.Int32,
        //                ParameterDirection.Input
        //            );

        //            param.Add(
        //                "@BuyerId",
        //                hasBatchNo ? null : objparam.BuyerId,
        //                DbType.Int32,
        //                ParameterDirection.Input
        //            );

        //            param.Add(
        //                "@StyleId",
        //                hasBatchNo ? null : objparam.StyleId,
        //                DbType.Int32,
        //                ParameterDirection.Input
        //            );

        //            param.Add(
        //                "@Date",
        //                hasBatchNo ? null : objparam.Date,
        //                DbType.Date,
        //                ParameterDirection.Input
        //            );

        //            param.Add(
        //                "@OrderId",
        //                hasBatchNo ? null : objparam.OrderId,
        //                DbType.Int32,
        //                ParameterDirection.Input
        //            );

        //            param.Add(
        //                "@JobId",
        //                hasBatchNo ? null : objparam.JobId,
        //                DbType.Int32,
        //                ParameterDirection.Input
        //            );

        //            param.Add(
        //                "@BatchNo",
        //                hasBatchNo
        //                    ? objparam.BatchNo.Trim()
        //                    : null,
        //                DbType.String,
        //                ParameterDirection.Input
        //            );

        //            param.Add(
        //                "@ShiftId",
        //                hasBatchNo ? null : objparam.ShiftId,
        //                DbType.Int32,
        //                ParameterDirection.Input
        //            );
        //        }
        //        //==============================================
        //        // Load RDLC
        //        //==============================================
        //        string rdlcPath = Path.Combine(
        //            _webHostEnvironment.WebRootPath,
        //            "Reports",
        //            $"{cleanName}.rdlc"
        //        );

        //        if (!System.IO.File.Exists(rdlcPath))
        //            return NotFound($"RDLC file '{cleanName}.rdlc' not found.");

        //        var localReport = new LocalReport(rdlcPath);

        //        //==============================================
        //        // Load Data
        //        //==============================================
        //        if (originalReportName == "Date Wise Hourly QC Report")
        //        {
        //            DataSet ds = await _service.ExecuteStoredProcedureToDataSetAsync(query, param);

        //            localReport.AddDataSource("dsDateWiseHourlyQCReport", ds.Tables[0]);
        //            localReport.AddDataSource("dsDateWiseHourlyQCReportSummary", ds.Tables[1]);
        //        }

        //        //==============================================
        //        // Parameters
        //        //==============================================
        //        var parameters = new Dictionary<string, string>();

        //        //if (originalReportName == "Date Wise Hourly QC Report")
        //        //{

        //        //    parameters.Add("ReportHeader", originalReportName);
        //        //}
        //        if (originalReportName == "Date Wise Hourly QC Report")
        //        {
        //            parameters.Add("ReportHeader", "Hourly QC Pass & DHU Report");
        //        }
        //        //==============================================
        //        // Render Report
        //        //==============================================
        //        RenderType renderType = reportType == "PDF"
        //            ? RenderType.Pdf
        //            : RenderType.ExcelOpenXml;

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

        //            string url = $"{Request.Scheme}://{Request.Host}/reports/{fileName}?t={DateTime.Now.Ticks}";

        //            return Ok(new { url });
        //        }

        //        return File(result.MainStream, mimeType, fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

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

                // ==============================================
                // Determine RDLC based on Shift
                // ==============================================
                string rdlcReportName = originalReportName;

                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    // Shift is NOT mandatory.
                    // If ShiftId = 1 => M Shift report
                    // Otherwise => default report
                    rdlcReportName = objparam.ShiftId == 1
                        ? "DateWiseHourlyQCReportMShift"
                        : "DateWiseHourlyQCReport";
                }

                string cleanName = Regex.Replace(
                    rdlcReportName,
                    @"\s+",
                    ""
                );

                // ==============================================
                // Get Stored Procedure
                // ==============================================
                string query = _service.GetStoredProcedure(originalReportName);

                var param = new DynamicParameters();

                // ==============================================
                // Date Wise Hourly QC Report
                // ==============================================
                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    /*
                     * NO REQUIRED FIELD VALIDATION HERE.
                     *
                     * BatchNo selected:
                     *   BatchNo = value
                     *   Everything else can be NULL.
                     *
                     * BatchNo not selected:
                     *   UnitId, BuyerId, JobId, StyleId,
                     *   OrderId, Date, ShiftId are passed
                     *   to the SP.
                     *
                     * The SP decides how to filter.
                     */

                    param.Add(
                        "@UnitId",
                        objparam.UnitId,
                        DbType.Int32,
                        ParameterDirection.Input
                    );

                    param.Add(
                        "@BuyerId",
                        objparam.BuyerId,
                        DbType.Int32,
                        ParameterDirection.Input
                    );

                    param.Add(
                        "@StyleId",
                        objparam.StyleId,
                        DbType.Int32,
                        ParameterDirection.Input
                    );

                    param.Add(
                        "@Date",
                        objparam.Date,
                        DbType.Date,
                        ParameterDirection.Input
                    );

                    param.Add(
                        "@OrderId",
                        objparam.OrderId,
                        DbType.Int32,
                        ParameterDirection.Input
                    );

                    param.Add(
                        "@JobId",
                        objparam.JobId,
                        DbType.Int32,
                        ParameterDirection.Input
                    );

                    param.Add(
                        "@BatchNo",
                        string.IsNullOrWhiteSpace(objparam.BatchNo)
                            ? null
                            : objparam.BatchNo.Trim(),
                        DbType.String,
                        ParameterDirection.Input
                    );

                    param.Add(
                        "@ShiftId",
                        objparam.ShiftId,
                        DbType.Int32,
                        ParameterDirection.Input
                    );
                }

                // ==============================================
                // Load RDLC
                // ==============================================
                string rdlcPath = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "Reports",
                    $"{cleanName}.rdlc"
                );

                if (!System.IO.File.Exists(rdlcPath))
                {
                    return NotFound(
                        $"RDLC file '{cleanName}.rdlc' not found."
                    );
                }

                var localReport = new LocalReport(rdlcPath);

                // ==============================================
                // Load Data
                // ==============================================
                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    DataSet ds =
                        await _service.ExecuteStoredProcedureToDataSetAsync(
                            query,
                            param
                        );

                    localReport.AddDataSource(
                        "dsDateWiseHourlyQCReport",
                        ds.Tables[0]
                    );

                    localReport.AddDataSource(
                        "dsDateWiseHourlyQCReportSummary",
                        ds.Tables[1]
                    );
                }

                // ==============================================
                // Report Parameters
                // ==============================================
                var parameters = new Dictionary<string, string>();

                if (originalReportName == "Date Wise Hourly QC Report")
                {
                    parameters.Add(
                        "ReportHeader",
                        "Hourly QC Pass & DHU Report"
                    );
                }

                // ==============================================
                // Render Report
                // ==============================================
                RenderType renderType =
                    reportType == "PDF"
                        ? RenderType.Pdf
                        : RenderType.ExcelOpenXml;

                var result = localReport.Execute(
                    renderType,
                    1,
                    parameters,
                    ""
                );

                string fileName =
                    reportType == "PDF"
                        ? $"{cleanName}.pdf"
                        : $"{cleanName}.xlsx";

                string mimeType =
                    reportType == "PDF"
                        ? "application/pdf"
                        : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                string filePath = Path.Combine(
                    _webHostEnvironment.WebRootPath,
                    "reports",
                    fileName
                );

                if (reportType == "PDF")
                {
                    System.IO.File.WriteAllBytes(
                        filePath,
                        result.MainStream
                    );

                    string url =
                        $"{Request.Scheme}://{Request.Host}/reports/{fileName}?t={DateTime.Now.Ticks}";

                    return Ok(new { url });
                }

                return File(
                    result.MainStream,
                    mimeType,
                    fileName
                );
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

        private byte[] GenerateQrCode(string text, bool quietZone = true)
        {
            using var generator = new QRCodeGenerator();
            using var data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

            // ✅ BEST FOR .NET 6 (NO System.Drawing ISSUE)
            var qrCode = new PngByteQRCode(data);
            return qrCode.GetGraphic(20, new byte[] { 0, 0, 0 }, new byte[] { 255, 255, 255 }, quietZone);
        }

        #endregion

        #region BATCH CARD V3 (DUBLICATE) SHAPING

        // rpt_sp_BatchCardPreviewDublicate returns one row per (size x process step).
        // BatchCardPreviewDublicate.rdlc reads ONE row with fixed columns (the reporting engine cannot run
        // RDLC expressions on .NET), so everything is formatted and pivoted here.
        private static DataTable FlattenBatchCardV3(DataTable src)
        {
            const int MaxSizes = 15, MaxProcesses = 4;
            var inv = System.Globalization.CultureInfo.InvariantCulture;

            string S(DataRow r, string col) =>
                src.Columns.Contains(col) && r[col] != DBNull.Value ? Convert.ToString(r[col], inv)?.Trim() ?? "" : "";
            string Num(string v) => decimal.TryParse(v, System.Globalization.NumberStyles.Any, inv, out var d) ? d.ToString("0.##", inv) : v;
            // design shows "9/26/2026 12:55:03 PM"; date-only values (midnight) print without the time
            string Dt(DataRow r, string col)
            {
                if (!src.Columns.Contains(col) || r[col] == DBNull.Value) return "";
                if (r[col] is DateTime d) return d.TimeOfDay == TimeSpan.Zero ? d.ToString("M/d/yyyy", inv) : d.ToString("M/d/yyyy h:mm:ss tt", inv);
                return Convert.ToString(r[col], inv) ?? "";
            }
            // Tahoma ≈ 0.0068in per char per pt: shrink from basePt so text fits widthIn, never below 5pt
            string Fit(string text, double widthIn, double basePt) =>
                (text.Length == 0 ? basePt : Math.Round(Math.Max(5, Math.Min(basePt, widthIn / (text.Length * 0.0068))), 1)).ToString("0.0", inv) + "pt";
            // process-grid slot widths (in) from the design: slot 1..4
            double[] slotW = { 1.45, 1.62, 1.39, 1.26 };

            var cols = new List<string>
            {
                "BatchNo", "CBN", "Buyer", "JobNo", "StyleNo", "OrderNo", "DocumentNo", "EffectiveDate", "RevisionDate", "RevisionNo",
                "Process", "MachineNo", "Date", "ItemName", "Color", "Composition", "TotalPcs", "TotalKg",
                "QCName", "QCId", "ShadeOkMark", "ShadeNotOkMark", "BatchPrepareBy", "WashingSupervisor", "WashingInCharge",
                "ProcessFs", "MachineNoFs", "CompositionFs"
            };
            for (int i = 1; i <= MaxSizes; i++) cols.AddRange(new[] { $"Size{i}", $"Pcs{i}", $"Kg{i}" });
            for (int i = 1; i <= MaxProcesses; i++)
                foreach (var k in new[] { "Process", "Machine", "Load", "Unload", "Operation", "Operator", "ProcessFs", "MachineFs", "OperatorFs" }) cols.Add($"P{i}{k}");

            var dt = new DataTable();
            foreach (var c in cols) dt.Columns.Add(c, typeof(string));
            dt.Columns.Add("QrCode", typeof(byte[]));

            var first = src.Rows[0];
            var row = dt.NewRow();

            row["BatchNo"] = S(first, "BatchNo");
            row["CBN"] = S(first, "CBN");
            row["Buyer"] = S(first, "Buyer");
            row["JobNo"] = S(first, "JobNo");
            row["StyleNo"] = S(first, "StyleNo");
            row["OrderNo"] = S(first, "OrderNo");
            row["DocumentNo"] = S(first, "DocumentNo") != "" ? S(first, "DocumentNo") : "CKL-Wash-024";
            row["EffectiveDate"] = Dt(first, "EffectiveDate");
            row["RevisionDate"] = Dt(first, "RevisionDate");
            row["RevisionNo"] = S(first, "RevisionNo");
            row["Process"] = S(first, "Process");
            row["MachineNo"] = S(first, "MachineNo");
            row["Date"] = Dt(first, "Date");
            row["ItemName"] = S(first, "ItemName");
            row["Color"] = S(first, "Color");
            row["Composition"] = S(first, "Composition") == "none" ? "" : S(first, "Composition");
            row["TotalPcs"] = Num(S(first, "TotalPcs"));
            row["TotalKg"] = Num(S(first, "TotalKg"));
            row["QCName"] = S(first, "QCName");
            row["QCId"] = S(first, "QCId");
            row["BatchPrepareBy"] = S(first, "BatchPrepareBy");
            row["WashingSupervisor"] = S(first, "WashingSupervisor");
            row["WashingInCharge"] = S(first, "WashingInCharge");
            if (src.Columns.Contains("QrCode") && first["QrCode"] != DBNull.Value) row["QrCode"] = first["QrCode"];
            row["ProcessFs"] = Fit((string)row["Process"], 2.9, 8.16);
            row["MachineNoFs"] = Fit((string)row["MachineNo"], 2.9, 8.16);
            row["CompositionFs"] = Fit((string)row["Composition"], 2.42, 8.16);

            // Wingdings: 254 = checked box, 168 = empty box. ShadeStatus: 'Okay' | 'Not Okay' | NULL
            var shade = S(first, "ShadeStatus").ToUpperInvariant();
            row["ShadeOkMark"] = shade == "OKAY" ? "\u00FE" : "\u00A8";
            row["ShadeNotOkMark"] = shade == "NOT OKAY" ? "\u00FE" : "\u00A8";

            // sizes: one column per distinct size, in SP order
            var sizes = src.AsEnumerable().Where(r => S(r, "Size") != "")
                .GroupBy(r => S(r, "Size")).Select(g => g.First()).Take(MaxSizes).ToList();
            for (int i = 0; i < sizes.Count; i++)
            {
                row[$"Size{i + 1}"] = S(sizes[i], "Size");
                row[$"Pcs{i + 1}"] = Num(S(sizes[i], "Pcs"));
                row[$"Kg{i + 1}"] = Num(S(sizes[i], "Kg"));
            }

            // process steps: one slot per WashStartEnd row (StepNo)
            var steps = src.AsEnumerable().Where(r => S(r, "StepNo") != "")
                .GroupBy(r => S(r, "StepNo"))
                .OrderBy(g => int.TryParse(g.Key, out var n) ? n : int.MaxValue)
                .Select(g => g.First()).Take(MaxProcesses).ToList();
            for (int i = 0; i < steps.Count; i++)
            {
                var r = steps[i];
                row[$"P{i + 1}Process"] = S(r, "StepProcess");
                row[$"P{i + 1}Machine"] = S(r, "StepMachine");
                row[$"P{i + 1}Load"] = S(r, "LoadTime");
                row[$"P{i + 1}Unload"] = S(r, "UnloadTime");
                row[$"P{i + 1}Operation"] = S(r, "Operation") != "" ? S(r, "Operation") : S(r, "GroupName");
                row[$"P{i + 1}Operator"] = S(r, "OperatorName");
            }
            for (int i = 0; i < MaxProcesses; i++)
            {
                string p = $"P{i + 1}";
                row[$"{p}ProcessFs"] = Fit(row[$"{p}Process"] as string ?? "", slotW[i], i == 0 ? 8.16 : 7.56);
                row[$"{p}MachineFs"] = Fit(row[$"{p}Machine"] as string ?? "", slotW[i], 7.56);
                row[$"{p}OperatorFs"] = Fit(row[$"{p}Operator"] as string ?? "", slotW[i], 6.24);
            }

            dt.Rows.Add(row);
            return dt;
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