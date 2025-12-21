using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class TrackingNoDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public TrackingNoDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class TrackingNoDDLList
    {
        public string TrackingNo { get; set; }
    }
}
