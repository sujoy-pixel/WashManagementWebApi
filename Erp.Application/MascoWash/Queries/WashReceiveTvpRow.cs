using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class WashReceiveTvpRow
    {
        public string TrackingBatchNo { get; set; }
        public int FromUnitId { get; set; }
        public string TypeName { get; set; }
        public int? FabricationId { get; set; }
        public string Composition { get; set; }
        public int? IszId { get; set; }
        public int? ColorId { get; set; }
        public int? DressPartId { get; set; }
        public string OperationType { get; set; }
        public int? UOMId { get; set; }
        public string Size { get; set; }
        public decimal Qty { get; set; }
        public DateTime? ProbableDeliveryDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
    }

}
