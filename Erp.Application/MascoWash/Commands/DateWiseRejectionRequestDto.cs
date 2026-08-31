using System;

namespace Erp.Application.MascoWash.Queries
{
    /// <summary>
    /// Request payload for the Style-wise Rejection dashboard.
    /// Mirrors the parameters expected by [dbo].[SP_Get_StyleWiseRejectionData].
    /// </summary>
    public class DateWiseRejectionRequestDto
    {
        /// <summary>The QC unit (filter applied on QC_Master.UnitId).</summary>
        public int UnitId { get; set; }

        /// <summary>The buyer (filter applied on QC_Master.BuyerId).</summary>
        public int BuyerId { get; set; }

        /// <summary>Inclusive lower bound of the QC creation date window.</summary>
        public DateTime FromDate { get; set; }

        /// <summary>Inclusive upper bound of the QC creation date window.</summary>
        public DateTime ToDate { get; set; }
    }
}
