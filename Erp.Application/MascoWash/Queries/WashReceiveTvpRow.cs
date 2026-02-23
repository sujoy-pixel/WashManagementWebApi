using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class WashReceiveTvpRow
    {
        public string TrackingBatchNo { get; set; }
        public int FromUnitId { get; set; }
        public int BuyerId { get; set; }
        public int JobId { get; set; }
        public int StyleId { get; set; }
        public int OrderId { get; set; }
        public string TypeName { get; set; }
        public int FabricationId { get; set; }
        public string Composition { get; set; }
        public int? SizeId { get; set; }
        public int? GsmId { get; set; }
        public int? ColorId { get; set; }
        public int? DressPartId { get; set; }
        public string OperationType { get; set; }
        public int? UOMId { get; set; }
        public string Size { get; set; }
      
        public decimal Qty { get; set; }
        public DateTime? ProbableDeliveryDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        
    }
    public class ReceiveResult
    {
        public int ResultCode { get; set; }
        public int MasterId { get; set; }
        public string ReceiveNo { get; set; }
        public string Message { get; set; }
    }


}
