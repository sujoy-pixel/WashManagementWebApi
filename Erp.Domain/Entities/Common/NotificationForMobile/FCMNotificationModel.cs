using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Domain.Entities.Common.NotificationForMobile
{
    public class FCMNotificationModel
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("isAndroiodDevice")]
        public bool IsAndroiodDevice { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
