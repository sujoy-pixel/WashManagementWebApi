using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Commands
{
    public class BatchWishQCDataDto
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public int JobId { get; set; }
        public string JobNo { get; set; }
        public string Type { get; set; }
        public int FabricationId { get; set; }
        public string FabricationName { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public int DressPartId { get; set; }
        public string DressPart { get; set; }
        public int UomId { get; set; }
        public string UOM { get; set; }
        public DateTime PrepareDate { get; set; }
        public string TrackingNo { get; set; }
        public string BatchNo { get; set; }
        public int GoodGarments { get; set; }
        public int Repairable{ get; set; }
        public int Reject { get; set; }
        public bool IsQCSaved { get; set; }
        public int TotalQty { get; set; }
        public int TotalKg { get; set; }




        public int Id { get; set; }
  
        public int MachineId { get; set; }
        public string MachineNo { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int Priority { get; set; }
        public int SizeId { get; set; }
     
        public string Size { get; set; }
  
        public decimal Weight { get; set; }
        public decimal RemainingQty { get; set; }
        public decimal RemainingWeight { get; set; }
        public decimal RemainingKg { get; set; }
        public decimal AlreadyPreparedQty { get; set; }
        public decimal UsedWeight { get; set; }
        public decimal AlreadyPreparedKg { get; set; }
  
        public bool Shade { get; set; }
        public string OperationTime { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public decimal OperationWeight { get; set; }
    }

    public class BatchWiseQCSizeDto
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int Qty { get; set; }
        public int RejectQty { get; set; }
    }

    public class BatchWiseQCDataResult
    {
        public BatchWishQCDataDto Header { get; set; }
        public List<BatchWiseQCSizeDto> SizeList { get; set; } = new List<BatchWiseQCSizeDto>();
    }
}