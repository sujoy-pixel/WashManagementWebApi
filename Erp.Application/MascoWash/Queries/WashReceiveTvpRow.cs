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
    //public DataTable CreateWashReceiveTvpTable(List<WashReceiveTvpRow> rows)
    //{
    //    var dt = new DataTable();

    //    dt.Columns.Add("TrackingBatchNo", typeof(string));
    //    dt.Columns.Add("FromUnitId", typeof(int));
    //    dt.Columns.Add("TypeName", typeof(string));
    //    dt.Columns.Add("FabricationId", typeof(int));
    //    dt.Columns.Add("Composition", typeof(string));
    //    dt.Columns.Add("IszId", typeof(int));
    //    dt.Columns.Add("ColorId", typeof(int));
    //    dt.Columns.Add("DressPartId", typeof(int));
    //    dt.Columns.Add("OperationType", typeof(string));
    //    dt.Columns.Add("UOMId", typeof(int));
    //    dt.Columns.Add("Size", typeof(string));
    //    dt.Columns.Add("Qty", typeof(decimal));
    //    dt.Columns.Add("ProbableDeliveryDate", typeof(DateTime));
    //    dt.Columns.Add("ShipmentDate", typeof(DateTime));

    //    foreach (var r in rows)
    //    {
    //        dt.Rows.Add(
    //            r.TrackingBatchNo,
    //            r.FromUnitId,
    //            r.TypeName ?? (object)DBNull.Value,
    //            r.FabricationId ?? (object)DBNull.Value,
    //            r.Composition ?? (object)DBNull.Value,
    //            r.IszId ?? (object)DBNull.Value,
    //            r.ColorId ?? (object)DBNull.Value,
    //            r.DressPartId ?? (object)DBNull.Value,
    //            r.OperationType ?? (object)DBNull.Value,
    //            r.UOMId ?? (object)DBNull.Value,
    //            r.Size,
    //            r.Qty,
    //            r.ProbableDeliveryDate ?? (object)DBNull.Value,
    //            r.ShipmentDate ?? (object)DBNull.Value
    //        );
    //    }

    //    return dt;
    //}

}
