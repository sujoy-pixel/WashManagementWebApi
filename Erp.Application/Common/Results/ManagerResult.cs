using Erp.Application.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Results
{
    public class ManagerResult<T> : BaseResult
    {
        public ManagerResult()
        {
            this.messages = new List<ISystemMessage>();
        }

        public T Data { get; set; }
    }
}
