using Erp.Application.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Results
{
    public interface IBaseResult
    {
        List<ISystemMessage> messages { get; set; }
    }
}
