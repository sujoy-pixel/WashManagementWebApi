using Erp.Application.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Results
{
    public class BaseResult : IBaseResult, ISystemMessageList<ISystemMessage>
    {
        public List<ISystemMessage> messages { get; set; }

        public bool Success { get; set; }

        public void AddErrorMessage(string message)
        {
            this.messages.Add(new SystemMessage
            {
                Title = message,
                MessageType = SystemMessageType.Error.ToString()
            });
        }

        public void AddInfoMessage(string message)
        {
            this.messages.Add(new SystemMessage
            {
                Title = message,
                MessageType = SystemMessageType.Info.ToString()
            });
        }

        public void AddMessage(ISystemMessage message)
        {
            this.messages.Add(message);
        }

        public void AddSuccessMessage(string message)
        {
            this.messages.Add(new SystemMessage
            {
                Title = message,
                MessageType = SystemMessageType.Success.ToString()
            });
        }

        public void AddWarningMessage(string message)
        {
            this.messages.Add(new SystemMessage
            {
                Title = message,
                MessageType = SystemMessageType.Warning.ToString()
            });
        }
    }
}
