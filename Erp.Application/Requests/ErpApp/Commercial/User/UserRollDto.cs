using Erp.Application.Common.Interfaces;
using Erp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erp.Application.Requests.ErpApp.SCHOOL.User
{
    public class UserRollDto
    {
        public int User_Roll_Id { get; set; }
        public int School_Name_Id { get; set; }
        public int School_Branch_Id { get; set; }
        public string User_Roll { get; set; }
        public string Active_YN { get; set; }
        public string ActiveStatus { get; set; }
        public string SchoolNameEnglish { get; set; }
        public string SchoolNameBangla { get; set; }
        public string BranchNameEnglish { get; set; }
        public string BranchNameBangla { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string DeleteBy { get; set; }
       

    }
    public class UserCreateDto
    {
        public int User_Create_Id { get; set; }
        //public int School_Name_Id { get; set; }
        //public int School_Branch_Id { get; set; }
        public string User_Role { get; set; }
        public int User_Roll_Id { get; set; }
        public string User_Name { get; set; }
        public string Login_Name { get; set; }
        public string DesigEName { get; set; }
        public string User_Emp_Code { get; set; }
        public string User_Phone { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string User_Confirm_Password { get; set; }

        public string Active_YN { get; set; }
        public string ActiveStatus { get; set; }
        //public string SchoolNameEnglish { get; set; }
        //public string SchoolNameBangla { get; set; }
        //public string BranchNameEnglish { get; set; }
        //public string BranchNameBangla { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string DeleteBy { get; set; }
        public string token { get; set; }
        //public string ImageData { get; set;}

        public byte[] ImageData { get; set; }


    }

    public class SavePermissionDto
    {
        public List<PermissionDto> detail { get; set; }
    }
    public class PermissionDto
    {
        public int School_Name_Id { get; set; }
        public int School_Branch_Id { get; set; }
        public int User_Roll_Id { get; set; }
        public int Menu_Id { get; set; }
        public int Parent_Id { get; set; }
        public int LoopCount { get; set; }
    }
    public class PaymentAmountDto
    {
        public int Payment_Amount_Id { get; set; }
        public int School_Name_Id { get; set; }
        public int School_Branch_Id { get; set; }
        public string SchoolNameEnglish { get; set; }
        public string SchoolNameBangla { get; set; }
        public string BranchNameEnglish { get; set; }
        public string BranchNameBangla { get; set; }
        public int Fin_Year_Id { get; set; }
        public string Fin_Year { get; set; }

        public int Academic_Year_Id { get; set; }
        public string Academic_Year { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public string Payment_Type { get; set; }
        public string Payment_Type_Name { get; set; }
        public string Effective_Date { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Mode { get; set; }
        public string Payment_Mode_Name { get; set; }
        public string Active_YN { get; set; }
        public string ActiveStatus { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string DeleteBy { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
    }

    public class DropDown
    {
        public int value { get; set; }
        public string label { get; set; }    }
    }
