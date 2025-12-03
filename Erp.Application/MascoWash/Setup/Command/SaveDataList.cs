using Erp.Application.Common.Models;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using Erp.Domain.Entities.Commercial.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Commercial.Setup.Command
{
    public class SaveDataList:IRequest<Result>
    {
        public int Payment_Amount_Id { get; set; }
        public int School_Name_Id { get; set; }
        public int School_Branch_Id { get; set; }
        public string Fin_Year { get; set; }
        public string Academic_Year { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public List<SaveDataListDto> UserRoleList { get; set; }
    }
}
