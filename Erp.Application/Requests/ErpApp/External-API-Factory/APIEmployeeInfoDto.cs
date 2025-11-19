using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Requests.ErpApp.External_API_Factory
{


    public class APIEmployeeInfoDto
    {
        public int Id { get; set; }
        public string EmployeeID { get; set; }
        public string PunchCardNo { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Doj { get; set; }
        public string Company { get; set; }
        public string Unit { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public string Floor { get; set; }
        public string Line { get; set; }
        public string Designation { get; set; }
        public string StaffCategory { get; set; }
        public string Grade { get; set; }
        public int Active { get; set; }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string NameId { get; set; }


    }


    public class APITaxableEmployeeInfoDto
    {
        public int Id { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string TinNumber { get; set; }
        public double TaxAmount { get; set; }


    }


}
