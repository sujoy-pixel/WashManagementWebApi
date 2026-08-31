using MediatR;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    /// <summary>
    /// Response DTO for the Style-wise Rejection dashboard.
    ///
    /// NOTE on dynamic size columns:
    ///   The SP [dbo].[SP_Get_StyleWiseRejectionData] emits a dynamic
    ///   column set - the size columns vary per buyer (e.g. one buyer
    ///   may have [104],[110], another [XS],[S],[M],[L],[XL],[XXL]).
    ///   A static C# DTO cannot capture arbitrary column names, so
    ///   the SP result is read as IDictionary&lt;string, object&gt;
    ///   (one dictionary per row) at the repository layer and
    ///   projected into this DTO. The size columns are exposed both:
    ///     - individually on SizeRejects (Dictionary) for clients that
    ///       want to walk every size column
    ///     - as flat properties for the fixed columns
    ///
    ///   The keys of SizeRejects are EXACTLY the size column names
    ///   returned by the SP for this buyer (after the leading
    ///   underscore prefix used by some DB conventions is stripped).
    /// </summary>
    public class StyleWiseRejectionResponseDto
    {
        // ---- Fixed text columns (always present) ----
        public string ReceiveFrom { get; set; }
        public string Buyer { get; set; }
        public string Job { get; set; }
        public string Order { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string DressPart { get; set; }
        public string WashCategory { get; set; }
        public string ItemName { get; set; }

        // ---- Fixed numeric columns ----
        public decimal? ReceiveQty { get; set; }
        public string UoM { get; set; }
        public int? NoOfBatch { get; set; }
        public int? TotalCheckQty { get; set; }

        // ---- Dynamic size reject columns ----
        // Key   = size column name as returned by the SP (e.g. "104", "110", "XS", "L")
        // Value = reject qty for that size (0 if the cell was NULL in the SP result)
        public Dictionary<string, int> SizeRejects { get; set; }
            = new Dictionary<string, int>();

        // ---- Trailing fixed columns ----
        public int? TotalRejectQty { get; set; }
        public string RejectPercent { get; set; }
    }
}
