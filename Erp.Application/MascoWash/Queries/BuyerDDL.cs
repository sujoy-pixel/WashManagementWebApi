using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class BuyerDDL : IRequest<List<DropdownListDto1>>
    {
    }

    public class BuyerDDLList
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
    }
}
