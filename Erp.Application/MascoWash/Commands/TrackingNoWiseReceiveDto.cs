using System;

namespace Erp.Application.MascoWash.Queries
{
    public class TrackingNoWiseReceiveDto
    {
        public string TrackingNo { get; set; }
        public string ReceiveNo { get; set; }
        public string ReceivedBy { get; set; }

        public int FromUnitId { get; set; }
        public int MasterId { get; set; }
        public int DetailsId { get; set; }
        public int UnitId { get; set; }
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

        public string Fabrication { get; set; }    
        public string FabricationName { get; set; }
        public string Composition { get; set; }

        public int ISZID { get; set; }
        public int FabricationId { get; set; }
        public int GsmId { get; set; }
        public string GSM { get; set; }
        public string Size { get; set; }
        public decimal Qty { get; set; }

        public int ICLEID { get; set; }
        public string Color { get; set; }

        public int DressPartId { get; set; }
        public string DressPart { get; set; }

        public string OperationType { get; set; }

        public int? UOMDetailsId { get; set; }
     
        public string UOM { get; set; }
        public string BatchNo { get; set; }


        public DateTime ProbableDeliveryDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int? TotalQty { get; set; }
        public int? RemainingQty { get; set; }
        public int? AlreadyPreparedQty { get; set; }
        public  string  RevisionNo { get; set; }
        public int RevesionNo { get; set; }
        public  DateTime RevisionDate { get; set; }

    }
}
