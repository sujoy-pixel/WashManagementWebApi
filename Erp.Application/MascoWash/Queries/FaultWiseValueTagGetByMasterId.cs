using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class FaultWiseValueTagGetByMasterId : IRequest<List<FaultWiseValueTagDetailGetAll>>
    {
        public int FaultWiseMasterId { get; set; }
        public FaultWiseValueTagGetByMasterId(int FaultWiseMasterId)
        {
            this.FaultWiseMasterId = FaultWiseMasterId;
        }
    }
}
