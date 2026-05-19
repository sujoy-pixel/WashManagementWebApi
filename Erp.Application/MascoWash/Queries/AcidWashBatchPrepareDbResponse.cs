
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    // Same class used by QueryFirstOrDefaultAsync
    public class SaveAcidWashBatchPrepareResponse
    {
        public int ResultCode { get; set; }
        public string AcidBatchNo { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string Message { get; set; }
    }
}
