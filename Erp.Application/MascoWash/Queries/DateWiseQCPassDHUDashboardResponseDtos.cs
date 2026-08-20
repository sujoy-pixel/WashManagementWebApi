using System;

namespace Erp.Application.MascoWash.Queries
{
    public class DateWiseQCPassDHUDashboardResponseDtos
    {
        public DateTime? Date { get; set; }

        public string TrackingNo { get; set; }

        public string ReceiveFrom { get; set; }

        public string Buyer { get; set; }

        public string Job { get; set; }

        public string Order { get; set; }

        public string Style { get; set; }

        public string Color { get; set; }

        public string DressPart { get; set; }

        public string WashCategory { get; set; }

        public string ItemName { get; set; }

        public string Shift { get; set; }

        public string QCName { get; set; }

        public decimal? ReceiveQty { get; set; }

        public string UoM { get; set; }

        public string BatchNo { get; set; }

        public int? TotalCheckQty { get; set; }

        public int? TotalOkayQty { get; set; }

        public int? TotalDefectQty { get; set; }

        public string DefectPercent { get; set; }

        public int? DefectsBalanceQty { get; set; }

        public int? RectifyDefectsQty { get; set; }

        public int? TotalRejectQty { get; set; }

        public string RejectPercent { get; set; }
    }
}