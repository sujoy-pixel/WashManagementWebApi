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

        public int? RectifyDefectQty { get; set; }

        public int? TotalRejectQty { get; set; }

        public string RejectPercent { get; set; }
    }
}