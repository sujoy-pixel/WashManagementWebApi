using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class FabricationDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public FabricationDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class FabricationDDLList
    {
        public int ITEMID { get; set; }
        public string ItemCode { get; set; }
    }
}
