using System;

namespace Erp.Application.MascoWash.Queries
{
    /// <summary>
    /// One row per (receive Detail, existing Plan line) from
    /// SP_Get_DateWiseMachinePlanGrid. PlanId and every Plan* field are NULL for a
    /// receive detail that has no plan line yet - ready for first-time planning.
    /// ProcessIds/MachineIds are comma-concatenated id lists (e.g. "3,5,7") parsed
    /// client-side into the multi-checkbox selections.
    /// </summary>
    public class DateWiseMachinePlanGridResponseDto
    {
        public int OrderDetailId { get; set; }
        public string Buyer { get; set; }
        public string Job { get; set; }
        public string Style { get; set; }
        public string Order { get; set; }
        public string Type { get; set; }
        public string Fabrication { get; set; }
        public string Color { get; set; }
        public string DressPart { get; set; }
        public DateTime? RequiredDeliveryDate { get; set; }
        public string UoM { get; set; }
        public decimal? Qty { get; set; }

        public int? PlanId { get; set; }
        public decimal? PlanQty { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanEndDate { get; set; }
        public string ProcessIds { get; set; }
        public string MachineIds { get; set; }
        public string Remarks { get; set; }
    }
}
