
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class ShiftNameDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public ShiftNameDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class ShiftNameDDLList
    {
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
    }
}
