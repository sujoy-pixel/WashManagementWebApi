using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.RoleManagement
{
    public class BuyersUsersDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string Remarks { get; set; }
        public bool IsSelected { get; set; }
        public int DefaultBuyer { get; set; }
        public bool IsDefault { get; set; }
    }
    public class DropdownListDto
    {
        public int ID { get; set; }
        public int ID1 { get; set; }
        public string DisplayName { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        public string Option6 { get; set; }
        public string Option7 { get; set; }
        public string Option8 { get; set; }
        public string Option9 { get; set; }
        public string Option10 { get; set; }
        public string Option11 { get; set; }
        public string Option12 { get; set; }
        public string Option13 { get; set; }
        public string Option14 { get; set; }
        public string Option15 { get; set; }
        public string Option16 { get; set; }
    }

    public class DropdownListDtoWithArrayList
    {
        public string CashLcNo { get; set; }
        public string CashLcDate { get; set; }
        public string SupplierId { get; set; }
        public string CashLcBankId { get; set; }
        public string CashLcBranchId { get; set; }
        public string CashLcPiNo { get; set; }
        public string CashLcPiDate { get; set; }
        public string CashLcMpo { get; set; }
        public string AmendmentNo { get; set; }
        public string AmendmentDate { get; set; }
        public string CashLcPaymentType { get; set; }
        public string CashLcShipmentDate { get; set; }
        public string CashLcExpireDate { get; set; }
        public string CashLcQty { get; set; }
        public string CashLcValue { get; set; }
        public string CashLcTenor { get; set; }
        public string CashLcComments { get; set; }
        public List<ItemPopUp> _listItemPopUp { get; set; }
    }
    public class ItemPopUp
    {
        public int CashLcItemDetailId { get; set; }
        public int CashLcDetailId { get; set; }
        public string CashLcNo { get; set; }
        public int CashLcMasterId { get; set; }
        public string CashLcItemName { get; set; }
        public decimal CashLcItemQty { get; set; }
        public int CashLcItemUomId { get; set; }
        public decimal CashLcItemUnitValue { get; set; }
        public int CashLcItemCurrencyId { get; set; }
        public decimal CashLcItemTotalValue { get; set; }
        public string CashLcItemHsCode { get; set; }
        public decimal CashLcItemTerrifPer { get; set; }
    }

    public class AcceptancePaymentDto
    {
        public string B2BLCFTTRTGSDate { get; set; }
        public decimal B2bLcValue { get; set; }
        public string CurrencyCode { get; set; }
        public string ShipmentDate { get; set; }
        public string ExpireDate { get; set; }
        public string B2bTenor { get; set; }
        public string SupplierName { get; set; }
        public string PiNumber { get; set; }
        public string Mpo { get; set; }
        public string CommonLandingDate { get; set; }
        public int ShipmentClearanceDays { get; set; }
        public string EtdDate { get; set; }
        public string EtaDate { get; set; }
        public string ActualDispatchDate { get; set; }
        public string ReceiveDate { get; set; }
        public List<PaymentData>_ListPaymentGrid { get; set; }  

    }
    public class PaymentData
    {
        public int PaymentDetailId { get; set; }
        public string LcNo { get; set;}
        public string AcceptanceDate { get; set; }
        public decimal AcceptanceValue { get; set; }
        public decimal RemainingValue { get; set; }
        public decimal B2bLcValue { get; set; }
    }
    public class ProformaInvoiceReviseDataList
    {
        public int ProformaInvoiceForeignId { get; set; }
        public int ExporterUnitId { get; set; }
        public string ExportAddress { get; set; }
        public int ExporterBankId { get; set; }
        public int ExporterBranchId { get; set; }
        public string ExportBranchAddress { get; set; }
        public int BuyerId { get; set; }
        public string BuyerAddress { get; set; }
        public int BuyerBankId { get; set; }
        public string BuyerBankAddress { get; set; }
        public int ConsigneeId { get; set; }
        public string ConsigneeAddress { get; set; }
        public string NotifyParty { get; set; }
        public string NotifyAddress { get; set; }
        public string AccountRiskMessersName { get; set; }
        public string AccountRiskMessersAddress { get; set; }
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public string StyleInfo { get; set; }
        public int StyleId { get; set; }
        public string BuyerReferenceNo { get; set; }
        public string ReferenceNo { get; set; }
        public int ColorId { get; set; }
        public string ItemColorName { get; set; }
        public string ColorCode { get; set; }
        public string DescriptionOfGoods { get; set; }
        public string FabricDescription { get; set; }
        public decimal OrderQty { get; set; }
        public int NoOfPcs { get; set; }
        public decimal QtyInPcs { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipmentDate { get; set; }
        public string Commission { get; set; }
        public string Remarks { get; set; }
        public string PaymentMethod { get; set; }
        public string LcNo { get; set; }
        public string LcDate { get; set; }
        public int CurrencyId { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryDate { get; set; }
        public string ModeOfShipment { get; set; }
        public string CountryOfOrigin { get; set; }
        public int BillOfLadingId { get; set; }
        public string TransShipment { get; set; }
        public string PartialShipment { get; set; }
        public string DocumentsRequired { get; set; }
        public decimal ShipmentTolerancePer { get; set; }
        public string PortOfLoadingFrom { get; set; }
        public string PortOfLoadingTo { get; set; }
    }
    public class MachineDuplicateCheckModel
    {
        public int ExistsFlag { get; set; }
    }


}
