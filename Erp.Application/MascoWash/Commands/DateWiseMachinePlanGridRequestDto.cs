using System;

namespace Erp.Application.MascoWash.Commands
{
    /// <summary>
    /// Filter body for Setup/GetDateWiseMachinePlanGrid. Buyer/Style/FromDate/ToDate are
    /// mandatory per the BRD; Unit/Job/Order are optional refinements.
    /// </summary>
    public class DateWiseMachinePlanGridRequestDto
    {
        public int? UnitId { get; set; }
        public int BuyerId { get; set; }
        public int? JobId { get; set; }
        public int StyleId { get; set; }
        public int? OrderId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
