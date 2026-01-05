using System;

namespace Erp.Application.MascoWash.Queries
{
    public class TrackingNoWiseReceiveDto
    {
        public string TrackingNo { get; set; }

        public int FromUnitId { get; set; }
        public string FromUnitName { get; set; }

        public DateTime ReceiveDate { get; set; }

        public string BuyerNo { get; set; }
        public string BuyerName { get; set; }

        public string JobId { get; set; }
        public string JobInfo { get; set; }

        public string StyleNo { get; set; }
        public string StyleName { get; set; }

        public string OrderNo { get; set; }
        public string OrderId { get; set; }

        public string Type { get; set; }

        public int Fabrication { get; set; }
        public string FabricationName { get; set; }
        public string Composition { get; set; }

        public int ISZID { get; set; }
        public string GSM { get; set; }

        public int ICLEID { get; set; }
        public string Color { get; set; }

        public int DressPartId { get; set; }
        public string DressPart { get; set; }

        public string OperationType { get; set; }

        public int? UOMDetailsId { get; set; }
        public string UOM { get; set; }

        public string Size { get; set; }
        public decimal Qty { get; set; }

        public DateTime ProbableDeliveryDate { get; set; }
        public DateTime ShipmentDate { get; set; }
      
    }
}
