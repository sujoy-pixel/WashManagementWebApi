using System;

namespace Erp.Application.MascoWash.Commands
{
    /// <summary>
    /// Lightweight request DTO for the size-headers endpoint.
    /// Used to pre-load the dynamic size column headers before the user
    /// picks a date range and clicks View.
    /// </summary>
    public class StyleWiseRejectionSizesRequestDto
    {
        /// <summary>
        /// The QC unit ID (used to scope size columns by unit).
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// The buyer ID (used to scope size columns by buyer).
        /// </summary>
        public int BuyerId { get; set; }
    }
}
