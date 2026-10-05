namespace Erp.Application.MascoWash.Queries
{
    public class StyleWiseQCPassDHUDashboardResponseDtos
    {
        public string ReceiveForm { get; set; }

        public string Buyer { get; set; }

        public string Job { get; set; }

        public string Order { get; set; }

        public string Style { get; set; }

        public string Color { get; set; }

        public string DressPart { get; set; }

        public string WashCategory { get; set; }

        public string ItemName { get; set; }

        public decimal? ReceiveQty { get; set; }

        public string UoM { get; set; }

        public int? NoOfBatch { get; set; }

        public int? TotalCheckQty { get; set; }

        public int? TotalOkayQty { get; set; }

        public int? TotalDefectQty { get; set; }

        public string DefectPercent { get; set; }

        public int? DefectsBalanceQty { get; set; }

        public int? RectifyDefectsQty { get; set; }

        public int? TotalRejectQty { get; set; }

        public string RejectPercent { get; set; }

        /// <summary>Buyer|Job|Style|Order|Color|DressPart (comma-separated if a row holds several) - counted ONCE in totals.</summary>
        public string ReceiveKey { get; set; }

        /// <summary>True when every batch in the row is a re-wash batch.</summary>
        public bool? IsReWash { get; set; }
    }
}