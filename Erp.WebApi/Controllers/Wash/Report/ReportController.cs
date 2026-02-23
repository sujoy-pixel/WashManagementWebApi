using AspNetCore.Reporting;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using Castle.Core.Configuration;
using Dapper;
using Erp.Application.Common.Interfaces;
using Erp.Infrastructure.Persistence;
using Erp.Infrastructure.Services.MascoWash;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using static Erp.Infrastructure.Services.MascoWash.ReportService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text.RegularExpressions;
using System.Linq;

namespace Erp.WebApi.Controllers.MascoWash.Report
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
      
        public ReportService _service { get; set; }
        public ReportController(IMediator mediator, IWebHostEnvironment webHostEnvironment, ReportService service)
        {
            _mediator = mediator;
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _service = service;
        }
        #region Report 

        [HttpPost]
        [ActionName("ShowReport")]
        public async Task<IActionResult> Report([FromBody] ParamModel objparam)
        {
            try
            {
                string mimtype = "";
                string ReportNameShow = objparam.ReportName.Trim();             
                string downLoadReportName = Regex.Replace(ReportNameShow, @"\s+", ""); 
                string fileName = objparam.Type == "PDF" ? downLoadReportName+".pdf" : downLoadReportName+".xls";

                string filePath = Path.Combine(this._webHostEnvironment.WebRootPath, "reports", fileName);
                DynamicParameters param = new DynamicParameters();
                

                // Fetch data from the database
                string query = _service.GetStoredProcedure(ReportNameShow);

                    if (objparam != null)
                    {
                        if (ReportNameShow == "Date Wise Batch Plan Report")
                        {
                            param = new DynamicParameters();
                            //DateTimeOffset parsedFromDate = DateTimeOffset.Parse(objparam.FromDate);
                            //string formattedFromDate = parsedFromDate.ToString("MM/dd/yyyy");
                            //DateTimeOffset parsedToDate = DateTimeOffset.Parse(objparam.ToDate);
                            //string formattedToDate = parsedToDate.ToString("MM/dd/yyyy");
                            param.Add("@TrackingNo", objparam.TrackingNo);
                        }                      
                    
                }

                    else
                    {
                        param = new DynamicParameters();
                    }
                    
                

                DataTable dt = await _service.GetDataByDataTableReadOnly(query, param);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return BadRequest("No data available for the report.");
                }

                // Load the RDLC report
                var path = Path.Combine(this._webHostEnvironment.WebRootPath, "Reports", $"{downLoadReportName}.rdlc");
                if (!System.IO.File.Exists(path))
                {
                    return NotFound($"The specified report file '{downLoadReportName}.rdlc' was not found.");
                }

                var localReport = new LocalReport(Path.Combine(this._webHostEnvironment.WebRootPath, "Reports", $"{downLoadReportName}.rdlc"));
                var dataset = "ds" + downLoadReportName;
               
                localReport.AddDataSource(dataset.Trim(), dt);

                // Determine render type and file MIME type
                RenderType renderType = objparam.Type == "PDF" ? RenderType.Pdf : RenderType.ExcelOpenXml;
                string fileType = objparam.Type == "PDF"
                    ? "application/pdf"
                    : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                if (ReportNameShow == "Company And Master Lc Wise B2B Info")
                {
                    DateTimeOffset parsedFromDate = DateTimeOffset.Parse(objparam.FromDate);
                    string formattedFromDate = parsedFromDate.ToString("MM/dd/yyyy");
                    DateTimeOffset parsedToDate = DateTimeOffset.Parse(objparam.ToDate);
                    string formattedToDate = parsedToDate.ToString("MM/dd/yyyy");
                    parameters.Add("ReportHeader", ReportNameShow);
                    parameters.Add("FromDate", formattedFromDate);
                    parameters.Add("ToDate", formattedToDate);
                }

                // Render the report
                var reportResult = localReport.Execute(renderType, 1, parameters, mimtype);

                if (objparam.Type == "PDF")
                {
                    System.IO.File.WriteAllBytes(filePath, reportResult.MainStream);
                    string reportUrl = $"{Request.Scheme}://{Request.Host}/reports/{fileName}?t={DateTime.Now.Ticks}";
                    return Ok(new { url = reportUrl }); // ✅ Return URL for PDFs
                }
                else
                {
                    return File(reportResult.MainStream, fileType, fileName); // ✅ Directly download Excel
                }

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error generating report: {ex.Message}");
                return StatusCode(500, "An error occurred while generating the report.");
            }
        }

        public static string NumberToWords(decimal amount)
        {
            long taka = (long)amount;
            int paisa = (int)((amount - taka) * 100);

            string takaPart = $"{NumberToWordsInt(taka)} ";
            string paisaPart = paisa > 0 ? $" and {NumberToWordsInt(paisa)} " : "";

            return takaPart + paisaPart + " Only";
        }

        // Helper function for integer-to-words
        public static string NumberToWordsInt(long number)
        {
            if (number == 0) return "Zero";

            string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six",
                          "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve",
                          "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                          "Eighteen", "Nineteen" };

            string[] tensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty",
                         "Sixty", "Seventy", "Eighty", "Ninety" };

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += NumberToWordsInt(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWordsInt(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWordsInt(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWordsInt(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "") words += "and ";

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words.Trim();
        }


        /// <summary>
        /// Helper function for English and western format Start
        /// </summary>
        /// 
        public static string NumberToWordsLocal(decimal amount)
        {
            long whole = (long)amount;
            int fraction = (int)Math.Round((amount - whole) * 100); // handle decimals

            string words = NumberToWordsIntLocal(whole);

            if (fraction > 0)
            {
                // Convert each digit of the fraction individually (dot format)
                string fractionWords = string.Join(" ", fraction.ToString().Select(d => NumberToWordsIntLocal(int.Parse(d.ToString()))));
                words += " point " + fractionWords;
            }

            return words + " Only";
        }

        private static string NumberToWordsIntLocal(long number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumberToWordsIntLocal(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWordsInt(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWordsInt(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWordsInt(number / 100) + " Hundred ";
                number %= 100;
            }

            string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six",
                          "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve",
                          "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                          "Eighteen", "Nineteen" };

            string[] tensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty",
                         "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number > 0)
            {
                if (words != "")
                    words += "";

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words.Trim();
        }

        /////// <summary>
        /// Helper function for English and western format End
        /// </summary>


        public class ParamModel
        {
            public string ReportName { get; set; }
            public string Type { get; set; }
            public string TrackingNo { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
      
      
        }


        #endregion
    }
}
