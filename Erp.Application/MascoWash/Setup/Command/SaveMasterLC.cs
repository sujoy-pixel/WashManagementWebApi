using Erp.Application.Common.Models;
using Erp.Domain.Entities.Commercial.Setup;
using MediatR;
using Org.BouncyCastle.Asn1.Crmf;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erp.Application.Commercial.Setup.Command
{

    public class SaveMasterLC : IRequest<List<SaveListModel>>
    {
        public string MasterLcId { get; set; }
        public string MasterLcType { get; set; }
        public string AmendmentDate { get; set; }
        public string MasterLcFileNo { get; set; }
        public int UnitId { get; set; }
        public int BuyerId { get; set; }
        public string UDNo { get; set; }      
        public string CreatedBy { get; set; }    
        public List<SaveListModel> _listData { get; set; }
    }

   
    public class wrapperSaveObj
    {
        public List<SaveMasterLC> saveList { get; set; }
    }
    public class SaveListModel
    {
        public string MasterLcFileNo { get; set; }
        public int MasterLcDetailId { get; set; }
        public int MasterLcId { get; set; }
        public string MasterLcPiNo { get; set; }
        public string MasterLcPiDate { get; set; }
        public string MasterLcMpo { get; set; }
        public int StyleId { get; set; }
        public string JobId { get; set; }
        public string MasterLcItemDetails { get; set; }
        public decimal MasterLcQty { get; set; }
        public string MasterLcUom { get; set; }
        public string NoOfpcs { get; set; }
        public string MasterLcNo { get; set; }
        public string MasterLcDate { get; set; }
        public string MasterLcShipmentDate { get; set; }
        public string MasterLcExpireDate { get; set; }
        public decimal MasterLcValue { get; set; }
        public int MasterLcCurrencyId { get; set; }
        public decimal MasterLcExchangeRate { get; set; }
        public int LcBankId { get; set; }
        public int LcBranchId { get; set; }
        public decimal Discountper { get; set; }
        public string Tenor { get; set; }
        public string Remarks { get; set; }
        
        public string MasterLcTypeStatus { get; set; }
        public string DeemedType { get; set; }
        public string DraftMasterLc { get; set; }

        public int AmendmentNoLcWise { get; set; }
        public string AmendmentDateLcWise { get; set; }
    }
    public class MasterLCDataModel
    {
        public int MasterLcId { get; set; }
        public int MasterLcDetailId { get; set; }
        public string AmendmentDate { get; set; }
        public string MasterLcFileNo { get; set; }
        public string Udno { get; set; }
        public int UnitId { get; set; }
        public string UnitEName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string MasterLcPiNo { get; set; }
        public string MasterLcPiDate { get; set; }
        public string MasterLcMpo { get; set; }
        public int StyleId { get; set; }
        public string JobId { get; set; }
        public string MasterLcItemDetails { get; set; }
        public decimal MasterLcQty { get; set; }
        public int MasterLcUom { get; set; }
        public string NoOfpcs { get; set; }
        public string MasterLcNo { get; set; }
        public string MasterLcDate { get; set; }
        public string MasterLcShipmentDate { get; set; }
        public string MasterLcExpireDate { get; set; }
        public decimal MasterLcValue { get; set; }
        public int MasterLcCurrencyId { get; set; }
        public decimal MasterLcExchangeRate { get; set; }
        public int LcBankId { get; set; }
        public int LcBranchId { get; set; }
        public decimal Discountper { get; set; }
        public string Tenor { get; set; }
        public string Remarks { get; set; }
        
        public string MasterLcTypeStatus { get; set; }
        public string DeemedType { get; set; }
        public string DraftMasterLc { get; set; }

        public int AmendmentNoLcWise { get; set; }
        public string AmendmentDateLcWise { get; set; }
        public int CountAmendmentNo { get; set; }


    }
    public class MasterLCDataModelWithPopUp
    {
        public int MasterLcId { get; set; }
        public int MasterLcDetailId { get; set; }
        public string AmendmentDate { get; set; }
        public string MasterLcFileNo { get; set; }
        public string Udno { get; set; }
        public int UnitId { get; set; }
        public string UnitEName { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string MasterLcPiNo { get; set; }
        public string MasterLcPiDate { get; set; }
        public string MasterLcMpo { get; set; }
        public int StyleId { get; set; }
        public string JobId { get; set; }
        public string MasterLcItemDetails { get; set; }
        public decimal MasterLcQty { get; set; }
        public int MasterLcUom { get; set; }
        public string NoOfpcs { get; set; }
        public string MasterLcNo { get; set; }
        public string MasterLcDate { get; set; }
        public string MasterLcShipmentDate { get; set; }
        public string MasterLcExpireDate { get; set; }
        public decimal MasterLcValue { get; set; }
        public int MasterLcCurrencyId { get; set; }
        public decimal MasterLcExchangeRate { get; set; }
        public int LcBankId { get; set; }
        public int LcBranchId { get; set; }
        public decimal Discountper { get; set; }
        public string Tenor { get; set; }
        public string Remarks { get; set; }
        
        public string MasterLcTypeStatus { get; set; }
        public string DeemedType { get; set; }
        public string DraftMasterLc { get; set; }

        public int AmendmentNoLcWise { get; set; }
        public string AmendmentDateLcWise { get; set; }
        public int CountAmendmentNo { get; set; }
        public List<LcWiseAmendPopup> _ListPopUp { get; set; }

    }
    public class MasterLCDataAmendmentModel
    {
        public string lcDate { get; set; }
        public string udno { get; set; }
        public int lcBankId { get; set; }
        public int lcBranchId { get; set; }
        public string piNumber { get; set;}
        public string piDate { get; set; }
        public string mpo { get; set; }
        public int amendmentNo { get; set; }
        public string amendmentDate { get; set; }
        public string itemDetails { get; set; }
        public decimal qty { get; set; }
        public string uom { get; set; }
        public string noOfpcs { get; set; }
        public string shipmentDate { get; set; }
        public string expireDate { get; set; }
        public decimal lcValue { get; set; }
        public int currencyId { get; set; }
        public int checkData { get; set; }
        public decimal discountper { get; set; }
        public string tenor { get; set; }
        public decimal exchangeRate { get; set; }
        public int buyerId { get; set; }
        public int styleId { get; set; }
        public string jobId { get; set; }
        public string comments { get; set; }
       

    }
    public class LcWiseAmendPopup
    {
        public int MasterLcId { get; set; }
        public int AmendmentNo { get; set; }
        public string AmendmentDate { get; set; }
        public string MasterLcNo { get; set; }
        public string OperatorTypeQty { get; set; }
        public decimal AmendmentMasterLcQty { get; set; }
        public string OperatorTypeValue { get; set; }
        public decimal AmendmentMasterLcValue { get; set; }

        public decimal MasterLcQty { get; set; }
        public decimal MasterLcValue { get; set; }
        public string MasterLcShipmentDate { get; set; }
        public string MasterLcExpireDate { get; set; }
        public string Tenor { get; set; }
        public string Comments { get; set; }
       

    }
}

