using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Commands
{

    public class SaveWashBatchPrepareModel : IRequest<Result>
    {
        public WashPrepareMasterDto Master { get; set; }
        public List<WashPrepareSizeDetailDto> SizeDetails { get; set; }
    }



    public class WashPrepareMasterDto
    {
       


        public string operation { get; set; }        // INSERT / UPDATE
        public string createdBy { get; set; }
        public int masterId { get; set; }

        public int unitId { get; set; }
        public string trackingNo { get; set; }

        // Display Fields
        public string batchNo { get; set; }
        public string type { get; set; }
        public string documentNo { get; set; }
        public DateTime? effectiveDate { get; set; }
        public DateTime? revisionDate { get; set; }
        public string revisionNo { get; set; }
       
        public DateTime? date { get; set; }
        public string composition { get; set; }
        // Master IDs
        public int buyerId { get; set; }
        public int jobId { get; set; }
        public int styleId { get; set; }
        public int orderId { get; set; }
        public int fabricationId { get; set; }
        public int? colorId { get; set; }
        public int? dressPartId { get; set; }
        public int? uomId { get; set; }
        public int? iszId { get; set; }

        // CSV IDs
        public string processIds { get; set; }
        public string machineIds { get; set; }

        // Totals
        public int totalPcs { get; set; }
        public decimal totalKg { get; set; }

        public bool IsManualTotal { get; set; }
        public bool shade { get; set; }
    }


    public class WashPrepareSizeDetailDto
    {
        public int? sizeId { get; set; }
        public string size { get; set; }
        public int qty { get; set; }
        public decimal kg { get; set; }
    }




}