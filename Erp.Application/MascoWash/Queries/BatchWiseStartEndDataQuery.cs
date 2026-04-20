
using Erp.Application.MascoWash.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Erp.Application.MascoWash.Queries
{
    public class BatchWiseStartEndDataQuery : IRequest<List<BatchWishQCDataDto>>
    {


        public string batchNo { get; }



        public BatchWiseStartEndDataQuery(string BatchNo)
        {
            batchNo = BatchNo;


        }
    }
}





