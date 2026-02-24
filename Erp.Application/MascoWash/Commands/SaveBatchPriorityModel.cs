using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Commands
{
    // ===============================
    // 🔥 MAIN COMMAND (Bulk Save)
    // ===============================
    public class SaveBatchPriorityModel : IRequest<WrapperResponseBatchPriority>
    {
        public List<BatchPriorityRow> Rows { get; set; } = new();
    }

    // ===============================
    // 🔥 EACH ROW
    // ===============================
    public class BatchPriorityRow
    {
        public string CreatedBy { get; set; }
        public int UnitId { get; set; }
        public DateTime Date { get; set; }
        public string BatchNo { get; set; }
        public int MachineId { get; set; }
        public int Priority { get; set; }
        public decimal Qty { get; set; }
        public int BuyerId { get; set; }
        public int JobId { get; set; }
        public int StyleId { get; set; }
        public int OrderId { get; set; }
        public int ColorId { get; set; }
    }

    // ===============================
    // 🔥 RESPONSE WRAPPER
    // ===============================
    public class WrapperResponseBatchPriority
    {
        public string ResultCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
