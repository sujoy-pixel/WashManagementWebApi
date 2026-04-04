using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class SaveQCDataModel : IRequest<WrapperResponseQCData>
    {
        public QCMasterRow Master { get; set; }

        // ✅ Separate lists (CORRECT)
        public List<QCDetailRow> RepairableDetails { get; set; } = new();
        public List<QCDetailRow> RejectDetails { get; set; } = new();
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

        public string Type { get; set; }
        public string Color { get; set; }

        public int GoodGarments { get; set; }

        // ✅ SUMMARY COUNTS (FROM UI)
        public int Repairable { get; set; }   // from this.repairable
        public int Reject { get; set; }       // from this.reject
    }
    public class QCDetailRow
    {
        public int DefectId { get; set; }
        public int Qty { get; set; }
    }
    public class WrapperResponseQCData
    {
        public string ResultCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public int? MasterId { get; set; }
    }
}
