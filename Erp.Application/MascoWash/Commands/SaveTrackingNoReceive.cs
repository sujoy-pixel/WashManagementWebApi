using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
namespace Erp.Application.MascoWash.Commands
{
    public class SaveTrackingNoReceive : IRequest<Result>
    {
        public TrackingReceiveMasterDto Master { get; set; }
        public List<TrackingReceiveDetailDto> Details { get; set; }
    }

  
        public class TrackingReceiveMasterDto
        {
            public string Operation { get; set; }   // INSERT | UPDATE
            public int? MasterId { get; set; }      // Required for UPDATE
            public string CreatedBy { get; set; }
            public int UnitId { get; set; }
            public string TrackingNo { get; set; }   // TrackingNo
        }



    public class TrackingReceiveDetailDto
    {
        public string TrackingBatchNo { get; set; }
        public int FromUnitId { get; set; }
        public DateTime ReceiveDate { get; set; }

        public string TypeName { get; set; }
        public int? FabricationId { get; set; }
        public string Composition { get; set; }
        public int? IszId { get; set; }
        public int? ColorId { get; set; }
        public int? DressPartId { get; set; }
        public string OperationType { get; set; }
        public int? UOMId { get; set; }

        public decimal? TotalQty { get; set; }
        public DateTime? ProbableDeliveryDate { get; set; }
        public DateTime? ShipmentDate { get; set; }

        // 🔥 IMPORTANT: SIZE DETAILS
        public List<TrackingReceiveSizeDto> SizeDetails { get; set; } = new();
    }
    public class TrackingReceiveSizeDto
    {
        public string Size { get; set; }
        public decimal Qty { get; set; }
    }
}

//namespace Erp.Application.MascoWash.Commands
//{
//    public class SaveTrackingNoReceive : IRequest<Result>
//    {
//        public string Operation { get; set; }   // INSERT | UPDATE
//        public int? MasterId { get; set; }      // Required for UPDATE
//        public string CreatedBy { get; set; }

//        public List<TrackingReceiveDetailModel> DetailList { get; set; } = new();
//    }

//    public class TrackingReceiveDetailModel
//    {
//        public int DetailsId { get; set; }
//        public int MasterId { get; set; }
//        public string TrackingBatchNo { get; set; }
//        public int FromUnitId { get; set; }
//        public DateTime ReceiveDate { get; set; }

//        public string TypeName { get; set; }
//        public int? FabricationId { get; set; }
//        public string Composition { get; set; }
//        public int? IszId { get; set; }
//        public int? ColorId { get; set; }
//        public int? DressPartId { get; set; }
//        public string OperationType { get; set; }
//        public int? UOMId { get; set; }
//        public decimal? TotalQty { get; set; }
//        public DateTime? ProbableDeliveryDate { get; set; }
//        public DateTime? ShipmentDate { get; set; }
//    }
//}
