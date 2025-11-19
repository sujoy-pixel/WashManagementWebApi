using System;
using System.Threading.Tasks;

using Erp.Application.Common.Interfaces;

namespace Erp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime? ConvertDateToBangladeshDateFormat(DateTime? dateTime)
        {
            if (dateTime != null)
            {
                TimeZoneInfo BdZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
                DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dateTime, BdZone);
                return localDateTime;
            }
            return null;
        

            
        }
    }
}
