using System;

public class DateWiseBalanceDashboardResponseDto
{
    // ---- shared dimensions (both views) ----
    public DateTime? Date { get; set; }
    public string ReceiveFrom { get; set; }
    public string Buyer { get; set; }
    public string Job { get; set; }
    public int? Order { get; set; }              // SP: DF.OrderId AS [Order]
    public string Style { get; set; }
    public string Color { get; set; }
    public string DressPart { get; set; }
    public string GSM { get; set; }
    public string FabricComposition { get; set; }
    public DateTime? ShipmentDate { get; set; }
    public string WashType { get; set; }

    // ---- ViewType = 1 : Garments (Pcs) ----
    public string FabricConPerDzn { get; set; }
    public decimal? OrderQty { get; set; }
    public decimal? ReceiveQty { get; set; }
    public decimal? CumReceiveQty { get; set; }
    public decimal? DeliveryQty { get; set; }
    public decimal? CumDeliveryQty { get; set; }
    public decimal? ApprovalTrail { get; set; }
    public decimal? BalanceQty { get; set; }

    // ---- ViewType = 2 : Fabric & Cutting Parts (Kg) ----
    public string BatchLot { get; set; }
    public int? Dia { get; set; }
    public decimal? OrderQtyKg { get; set; }
    public int? ReceiveRoll { get; set; }
    public decimal? ReceiveQtyKg { get; set; }
    public decimal? CalculatedQtyKg { get; set; }
    public int? DeliveryRoll { get; set; }
    public decimal? DeliveryQtyKg { get; set; }
    public decimal? CalculatedDeliveryQtyKg { get; set; }
    public decimal? BalanceQtyKg { get; set; }
}