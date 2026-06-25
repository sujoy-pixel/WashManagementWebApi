

//using Erp.Application.MascoWash.Commands;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace Erp.Application.MascoWash.Queries
//{
//    public class BatchWishQCDataQuery : IRequest<List<BatchWishQCDataDto>>
//    {


//        public string batchNo { get; }



//        public BatchWishQCDataQuery(string BatchNo)
//        {
//            batchNo = BatchNo;


//        }
//    }
//}



using Erp.Application.MascoWash.Commands;
using MediatR;

namespace Erp.Application.MascoWash.Queries
{
    public class BatchWishQCDataQuery : IRequest<BatchWiseQCDataResult>
    {
        public string batchNo { get; }

        public BatchWishQCDataQuery(string batchNo)
        {
            this.batchNo = batchNo;
        }
    }
}