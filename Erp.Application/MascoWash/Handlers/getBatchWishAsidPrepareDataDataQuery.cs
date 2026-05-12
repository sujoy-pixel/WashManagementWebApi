

using Erp.Application.MascoWash.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Erp.Application.MascoWash.Queries
{
    public class getBatchWishAsidPrepareDataDataQuery : IRequest<List<BatchWishQCDataDto>>
    {


        public string batchNo { get; }



        public getBatchWishAsidPrepareDataDataQuery(string BatchNo)
        {
            batchNo = BatchNo;


        }
    }
}





