using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Common.Notifications.Query
{
    public class GetNotificationsHandler : IRequestHandler<GetNotifications, List<NotificationDto>>
    {
        private readonly INotifications _notification;
        public GetNotificationsHandler(INotifications notification)
        {
            _notification = notification;
        }

        public async Task<List<NotificationDto>> Handle(GetNotifications request, CancellationToken cancellationToken)
        {
            return await _notification.GetNotifications();
        }
    }
}
