using System;

public class DateWiseBalanceDashboardRequestDto
{
    public int UnitId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public int ViewType { get; set; } = 1;   // 1 = Garments, 2 = Fabric & Cutting Parts
}