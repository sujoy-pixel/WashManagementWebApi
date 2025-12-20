using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class JobDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public JobDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class JobDDLList
    {
        public int JobNo { get; set; }
        public string JobInfo { get; set; }
    }
}
