using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Messages
{
    public class SystemMessage : ISystemMessage
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Body { get; set; }
        public string MessageType { get; set; }
    }
}
