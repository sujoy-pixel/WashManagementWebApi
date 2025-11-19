using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Notifications.Query
{
    public class GetNotifications : IRequest<List<NotificationDto>>
    {
    }
}
