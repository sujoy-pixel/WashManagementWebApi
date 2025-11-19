using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.SCHOOL.User.Command
{
    public class NewPaymentAmount : IRequest<Result>
    {
        public int Payment_Amount_Id { get; set; }
        public int School_Name_Id { get; set; }
        public int School_Branch_Id { get; set; }
        public string Fin_Year { get; set; }
        public string Academic_Year { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public string Payment_Type { get; set; }
        public string Effective_Date { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Mode { get; set; }
        public string Active_YN { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string DeleteBy { get; set; }


    }
}
