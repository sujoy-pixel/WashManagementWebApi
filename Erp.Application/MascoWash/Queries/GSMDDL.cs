using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class GSMDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public GSMDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class GSMDDLList
    {
        public int ISZID { get; set; }
        public string ItemSizeName { get; set; }
    }
}
