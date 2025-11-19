using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Messages
{
    public interface ISystemMessage
    {
        Guid id { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        string MessageType { get; set; }
    }
}
