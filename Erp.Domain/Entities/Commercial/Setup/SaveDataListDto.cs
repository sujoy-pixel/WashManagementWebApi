using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.Commercial.Setup
{
    public class SaveDataListDto
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
        public List<DetailList> detail { get; set; }
    }
    public class DetailList
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

}
