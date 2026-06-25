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