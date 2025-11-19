using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Common.Notifications.Command
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotification, Result>
    {
        private readonly INotifications _notification;

        public CreateNotificationHandler(INotifications notification)
        {
            _notification = notification;

        }
        public Task<Result> Handle(CreateNotification request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
