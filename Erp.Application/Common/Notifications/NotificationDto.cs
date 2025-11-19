using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Common.Notifications
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int NotificationTypeId { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public String FromUserId { get; set; }
        public string FromUserName { get; set; }
        public int ToUserId { get; set; }
        public string ToUserName { get; set; }
        public string NotificationHeader { get; set; }
        public string NotificationBody { get; set; }
        public int IsRead { get; set; }
        public string Url { get; set; }
    }
}
