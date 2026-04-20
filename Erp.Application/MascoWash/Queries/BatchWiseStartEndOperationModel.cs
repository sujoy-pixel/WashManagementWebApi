using System;

namespace Erp.Application.MascoWash.Queries
{
    public class WashStartEndResponseDtos
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public int BuyerId { get; set; }
        public string BatchNo { get; set; }
        public string ProcessId { get; set; }
        public string MachineId { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndTime { get; set; }
        public string Operation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MachineNames { get; set; }
        public string ProcessNames { get; set; }
    }
}
