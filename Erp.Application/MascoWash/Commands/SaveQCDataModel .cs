// ── Command Model ────────────────────────────
using MediatR;
using System;
using System.Collections.Generic;

public class SaveQCDataModel : IRequest<WrapperResponseQCData>
{
    public QCMasterRow Master { get; set; }
    public List<QCRepairableDetailRow> RepairableDetails { get; set; } = new();
    public List<QCRejectDetailRow> RejectDetails { get; set; } = new();
    public List<QCSizeDetailRow> SizeDetails { get; set; } = new();
}
public class QCSizeDetailRow
{
    public int SizeId { get; set; }
    public string SizeName { get; set; }
    public int Qty { get; set; }
    public int RejectQty { get; set; }
}

public class QCMasterRow
{
    public string CreatedBy { get; set; }
    public int UnitId { get; set; }
    public int BuyerId { get; set; }
    public int StyleId { get; set; }
    public int OrderId { get; set; }
    public int JobId { get; set; }
    public int DressPartId { get; set; }
    public int UomId { get; set; }
    public DateTime Date { get; set; }
    public string BatchNo { get; set; }
    public string TrackingNo { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public int? ColorId { get; set; }
    public int GoodGarments { get; set; }
    public int Repairable { get; set; }
    public int Reject { get; set; }
    public string MachineIds { get; set; }
    public string ProcessIds { get; set; }
}

public class QCRepairableDetailRow
{
    public int? GroupId { get; set; }
    public int DefectId { get; set; }
    public int Qty { get; set; }
}

public class QCRejectDetailRow
{
    public int? GroupId { get; set; }
    public int RejectId { get; set; }
    public int Qty { get; set; }
}

public class WrapperResponseQCData
{
    public string ResultCode { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int? MasterId { get; set; }
}

//namespace Erp.Application.MascoWash.Commands
//{
//    public class SaveAcidWashBatchPrepareCommand : IRequest<Result>
//    {
//        public AcidWashPrepareMasterDto Master { get; set; }
//        public List<AcidWashPrepareSizeDto> Details { get; set; }
//    }

//    public class AcidWashPrepareMasterDto
//    {
//        /// <summary>INSERT or UPDATE</summary>
//        public string Operation { get; set; } = "INSERT";

//        /// <summary>0 for INSERT, existing MasterId for UPDATE</summary>
//        public int MasterId { get; set; } = 0;

//        /// <summary>Source Wash Batch No — maps to BatchNo column</summary>
//        public string BatchNo { get; set; }

//        public decimal TotalPcs { get; set; }
//        public decimal TotalKg { get; set; }

//        /// <summary>Comma-separated process IDs</summary>
//        public string ProcessIds { get; set; }

//        /// <summary>Comma-separated machine IDs</summary>
//        public string MachineIds { get; set; }
//    }

//    public class AcidWashPrepareSizeDto
//    {
//        public int? SizeId { get; set; }
//        public string SizeName { get; set; }
//        public decimal SizeQty { get; set; }
//        public decimal SizeWeight { get; set; }
//    }

//    /// <summary>Maps directly to the SP result row</summary>
//    // Same class used by QueryFirstOrDefaultAsync
//    public class AcidWashBatchPrepareDbResponse
//    {
//        public int ResultCode { get; set; }
//        public string AcidBatchNo { get; set; }
//        public string CreatedBy { get; set; }
//        public DateTime CreatedDate { get; set; }
//        public string Message { get; set; }
//    }
//}