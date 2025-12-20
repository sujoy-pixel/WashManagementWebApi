using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class DressPartDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public DressPartDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class DressPartDDLList
    {
        public int DressId { get; set; }
        public string PartName { get; set; }
    }
}
