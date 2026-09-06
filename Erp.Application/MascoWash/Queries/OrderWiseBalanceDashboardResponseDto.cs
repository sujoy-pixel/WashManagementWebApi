using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    /// <summary>
    /// Order-wise Balance Dashboard row.
    /// Property names match the SP output aliases exactly, so Dapper's
    /// automatic column-to-property mapping works out of the box.
    /// ViewType = 1 fills the Pcs fields, ViewType = 2 fills the Kg fields.
    /// </summary>
    public class OrderWiseBalanceDashboardResponseDto
    {
        // ---------- COMMON ----------
        public string ReceiveFrom { get; set; }        // tblUnitInfo.USCode
        public string Buyer { get; set; }
        public string Job { get; set; }
        public string Order { get; set; }              // OrderId as string per BRD
        public string Style { get; set; }
        public string Color { get; set; }
        public string DressPart { get; set; }
        public string WashType { get; set; }
        public string FabricComposition { get; set; }
        public string GSM { get; set; }

        // ---------- VIEW TYPE = 2 ONLY ----------
        public string BatchLot { get; set; }           // comma-distinct per group
        public int? Dia { get; set; }                  // stub (0) until source confirmed

        // ---------- VIEW TYPE = 1 : GARMENTS / PCS ----------
        public decimal? FabricConPerDzn { get; set; }      // OrderQtyKg / (OrderQtyPcs / 12)
        public decimal? OrderQtyPcs { get; set; }
        public decimal? TotalReceiveQtyPcs { get; set; }
        public decimal? ReceiveBalancePcs { get; set; }    // OrderQtyPcs - TotalReceiveQtyPcs
        public decimal? TotalDeliveryQtyPcs { get; set; }
        public decimal? ReadyForDeliveryPcs { get; set; }  // TotalQCQty - TotalDeliveryQty
        public decimal? ApprovalTrail { get; set; }
        public decimal? DeliveryBalanceQtyPcs { get; set; }// TotalReceiveQty - TotalDeliveryQty

        // ---------- VIEW TYPE = 2 : FABRIC / KG ----------
        public decimal? OrderQtyKg { get; set; }
        public int? TotalReceiveRoll { get; set; }         // 0 until real source confirmed
        public decimal? TotalReceiveQtyKg { get; set; }
        public decimal? ReceiveBalanceKg { get; set; }     // OrderQtyKg - TotalReceiveQtyKg
        public int? TotalDeliveryRoll { get; set; }
        public decimal? TotalDeliveryQtyKg { get; set; }
        public decimal? ReadyForDeliveryKg { get; set; }
        public decimal? DeliveryBalanceKg { get; set; }    // TotalReceiveQty - TotalDeliveryQty

        // ---------- COMMON DATES / STATUS ----------
        public DateTime? ShipmentDate { get; set; }
        public DateTime? FirstReceiveDate { get; set; }
        public DateTime? LastReceiveDate { get; set; }
        public DateTime? FirstDeliveryDate { get; set; }
        public DateTime? LastDeliveryDate { get; set; }
        public string WashStatus { get; set; }
        public string Remarks { get; set; }            // DA.DeliveryRemarks
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Erp.Application.MascoWash.Queries
//{
//    // ===================================================================
//    // Garments (Pcs) view - one row per (Buyer, Job, Order, Style,
//    // Color, DressPart). Returned when ViewType == 1.
//    //
//    // Column aliases below EXACTLY match the SP's output aliases for
//    // @ViewType = 1, so Dapper's automatic column-to-property mapping
//    // works out of the box (no custom mapper needed).
//    // ===================================================================
//    public class OrderWiseBalanceDashboardResponseDto
//    {
//        public string ReceiveFrom { get; set; }   // tblUnitInfo.USCode
//        public string Buyer { get; set; }
//        public string Job { get; set; }
//        public string Order { get; set; }   // OrderId as string per BRD
//        public string Style { get; set; }
//        public string Color { get; set; }
//        public string DressPart { get; set; }
//        public string WashType { get; set; }
//        public string FabricComposition { get; set; }
//        public string GSM { get; set; }
//        public decimal? FabricConPerDzn { get; set; }   // Kg per dozen
//        public decimal? OrderQtyPcs { get; set; }
//        public DateTime? ShipmentDate { get; set; }
//        public DateTime? FirstReceiveDate { get; set; }
//        public DateTime? LastReceiveDate { get; set; }
//        public decimal? TotalReceiveQtyPcs { get; set; }
//        public decimal? ReceiveBalancePcs { get; set; }   // OrderQtyPcs - TotalReceiveQtyPcs
//        public DateTime? FirstDeliveryDate { get; set; }
//        public DateTime? LastDeliveryDate { get; set; }
//        public decimal? TotalDeliveryQtyPcs { get; set; }
//        public decimal? ReadyForDeliveryPcs { get; set; } // TotalQCQty - TotalDeliveryQty
//        public decimal? ApprovalTrail { get; set; }
//        public decimal? DeliveryBalanceQtyPcs { get; set; } // Receive - Delivery
//        public string WashStatus { get; set; }


//        public string BatchLot { get; set; }   // comma-distinct per group

//        public int? Dia { get; set; }
//        public decimal? OrderQtyKg { get; set; }

//        public int? TotalReceiveRoll { get; set; }
//        public decimal? TotalReceiveQtyKg { get; set; }
//        public decimal? ReceiveBalanceKg { get; set; }   // OrderQtyKg - TotalReceiveQtyKg

//        public int? TotalDeliveryRoll { get; set; }
//        public decimal? TotalDeliveryQtyKg { get; set; }
//        public decimal? ReadyForDeliveryKg { get; set; }   // TotalQCQty - TotalDeliveryQty
//        public decimal? DeliveryBalanceKg { get; set; }   // Receive - Delivery

//        public string Remarks { get; set; }   // DA.DeliveryRemarks
//    }
//}
