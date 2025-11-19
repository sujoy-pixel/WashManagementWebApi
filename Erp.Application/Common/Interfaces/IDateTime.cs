using System;
using System.Threading.Tasks;

namespace Erp.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }

        DateTime? ConvertDateToBangladeshDateFormat(DateTime? dateTime);
    }
}
