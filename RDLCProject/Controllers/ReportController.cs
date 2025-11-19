using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using RDLCProject.Service;
using System.Data;

namespace RDLCProject.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public  SalaryService _salaryService { get; set; }
     
        public ReportController(IWebHostEnvironment webHostEnvironment, SalaryService salaryService)
        {        
            this._webHostEnvironment = webHostEnvironment;
            this._salaryService = salaryService;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Print(string ReportName,string Type) 
        {
            string mimtype = "";
            int extension = 1;
            var path = "";
            var dt = new DataTable();
            dt = _salaryService.GetSalaryInfo();

            Dictionary<string, string> param = new Dictionary<string, string>();
            if (ReportName == "Report2")
            {
                path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\"+ReportName+".rdlc";             
                param.Add("rep1", "welcome to rdlc report");
            }
            else if(ReportName =="Report3")
            {
                path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\" + ReportName + ".rdlc";
                param.Add("rep1", "Employee Salary Report");
            }
            LocalReport localReport = new LocalReport(path);
            var dataset = "ds"+ ReportName;
            localReport.AddDataSource(dataset, dt);
            var renderType =new RenderType();
            var fileType = "";
            var fileName = "";

            if (Type =="PDF")
            {
                renderType = RenderType.Pdf;
                fileType = "application/pdf";
                fileName = "Report.pdf";
            }
            else if(Type == "Excel")
            {
                renderType = RenderType.Excel;
                fileType = "application/vnd.ms-excel";
                fileName = "Report.xls";
            }
        
            var result = localReport.Execute(renderType, extension, param, mimtype);
            return File(result.MainStream, fileType, fileName);

        }

    }
}
