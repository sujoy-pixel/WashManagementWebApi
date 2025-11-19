using System;

namespace Erp.Application.Common.Models
{
    public class RequestLoggerEntity
    {
        public int Id { get; set; }
        public string RequestName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public string UserIp { get; set; }
        //public string NetworkIp { get; set; }
        // public string DeviceName { get; set; }
        //public string Location { get; set; }
    }
}
