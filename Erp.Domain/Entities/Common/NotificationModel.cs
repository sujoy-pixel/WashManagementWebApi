using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Erp.Domain.Entities.Common
{
    [Table("NOTIFICATIONS")]
    public class NotificationModel:AuditableEntity
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NOTIFICATION_TYPE_ID")]
        public int NotificationTypeId { get; set; }
        [Column("USER_TYPE_ID")]
        public int UserTypeId { get; set; }
        [Column("FROM_USER_ID")]
        public string FromUserId { get; set; }
        [Column("TO_USER_ID")]
        public string ToUserId { get; set; }
        [Column("NOTIFICATION_HEADER")]
        public string NotificationHeader { get; set; }
        [Column("NOTIFICATION_BODY")]
        public string NotificationBody { get; set; }
        [Column("IS_READ")]
        public int IsRead { get; set; }
        [Column("URL")]
        public string Url { get; set; }
    }
}

