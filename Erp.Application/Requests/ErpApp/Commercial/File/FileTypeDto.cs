using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.SCHOOL.File
{
    public class FileTypeDto
    {
        public int FILE_TYPE_ID { get; set; }
        public string FILE_TYPE_NAME { get; set; }
        public int ActiveStatus { get; set; }

        public string Active_YN { get; set; }

        public string CreateBy { get; set; }
    }
}
