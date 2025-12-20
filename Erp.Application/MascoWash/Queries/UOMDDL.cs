using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class UOMDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public UOMDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class UOMDDLList
    {
        public int UOMDetailsId { get; set; }
        public string UOMDetails { get; set; }
    }
}
