using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class OrderDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public OrderDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class OrderDDLList
    {
        public int StyleId { get; set; }
        public string StyleInfo { get; set; }
    }
}
