// SaveAcidWashBatchPrepareCommand.cs
using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Commands
{
    public class SaveAcidWashBatchPrepareCommand : IRequest<Result>
    {
        public AcidWashPrepareMasterDto Master { get; set; }
        public List<AcidWashPrepareSizeDto> Details { get; set; }
    }

    public class AcidWashPrepareMasterDto
    {
        /// <summary>INSERT or UPDATE</summary>
        public string Operation { get; set; } = "INSERT";

        /// <summary>0 for INSERT, existing MasterId for UPDATE</summary>
        public int MasterId { get; set; } = 0;

        /// <summary>Source Wash Batch No — maps to BatchNo column</summary>
        public string BatchNo { get; set; }

        public decimal TotalPcs { get; set; }
        public decimal TotalKg { get; set; }

        /// <summary>Comma-separated process IDs</summary>
        public string ProcessIds { get; set; }

        /// <summary>Comma-separated machine IDs</summary>
        public string MachineIds { get; set; }
    }

    public class AcidWashPrepareSizeDto
    {
        public int? SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal SizeQty { get; set; }
        public decimal SizeWeight { get; set; }
    }

    /// <summary>Maps directly to the SP result row</summary>
    // Same class used by QueryFirstOrDefaultAsync
    public class AcidWashBatchPrepareDbResponse
    {
        public int ResultCode { get; set; }
        public string AcidBatchNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
    }
}