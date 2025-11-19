using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Notifications.Command
{
    public class CreateNotification : IRequest<Result>
    {

        public int Id { get; set; }
        public int NotificationTypeId { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string NotificationHeader { get; set; }
        public string NotificationBody { get; set; }
        public int IsRead { get; set; }
        public string Url { get; set; }
    }
}
