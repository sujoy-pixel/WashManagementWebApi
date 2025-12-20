using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class StyleDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public StyleDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class StyleDDLList
    {
        public int BuyerReferenceId { get; set; }
        public string BuyerReferenceNo { get; set; }
    }
}
