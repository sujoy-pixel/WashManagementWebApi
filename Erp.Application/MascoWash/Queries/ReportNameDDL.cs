
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class ReportNameDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public ReportNameDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class ReportNameDDLList
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
    }
}
