
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class BatchNoAutoCompleteDDL : IRequest<List<DropdownListDto1>>
    {
        public string ItemText { get; set; }

        public BatchNoAutoCompleteDDL(string itemText)
        {
            ItemText = itemText;
        }
    }

    public class DBatchNoAutoCompleteDDLList
    {
        public int BatchId { get; set; }
        public string BatchNo { get; set; }
    }
}
