using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.SCHOOL.User.Command
{
   public class NewUserCreate : IRequest<Result>
    {
        public int User_Create_Id { get; set; }
        public int School_Name_Id { get; set; }
        public int School_Branch_Id { get; set; }
        public string User_Role { get; set; }
        public int User_Roll_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Emp_Code { get; set; }
        public string User_Phone { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public string User_Confirm_Password { get; set; }
        public string Active_YN { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string DeleteBy { get; set; }


    }
}
