using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Erp.Domain.Common;
using Microsoft.AspNetCore.Http;

namespace Erp.Domain.Entities.CommonSettings
{
    [Table("M_FACTORY_SETTING")]
    public class FactorySettingModel : AuditableEntity
    {
        [Column("FACTORY_ID")]
        [Key]
        public int FactoryId { get; set; }

        [Column("FACTORY_NAME")]
        public string FactoryName { get; set; }

        [Column("ADDRESS")]
        public string Address { get; set; }

        [Column("BUYER_ID")]
        public int BuyerId { get; set; }
    }

    [Table("M_SIZE_SETUP_SETTING")]
    public class SizeSetupModel : AuditableEntity
    {
        [Column("SIZE_SETUP_ID")]
        [Key]
        public int SizeSetupId { get; set; }

        [Column("SIZE_CODE")]
        public string SizeCode { get; set; }

        [Column("SIZE_NAME")]
        public string SizeName { get; set; }

        [Column("INSEAM_OR_DIM")]
        public string InseamOrDim { get; set; }

        [Column("BUYER_ID")]
        public int BuyerId { get; set; }
    }

    [Table("M_STYLE_SETTING")]
    public class StyleSettingModel : AuditableEntity
    {
        [Column("STYLE_ID")]
        [Key]
        public int StyleId { get; set; }

        [Column("STYLE_NAME")]
        public string StyleName { get; set; }

        [Column("BUYER_ID")]
        public int BuyerId { get; set; }

        [Column("ITEM")]
        public string Item { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("SMV")]
        public string SMV { get; set; }

        [Column("BUYER_DEPARTMENT")]
        public string BuyerDepartment { get; set; }

        [Column("FILE_PATH")]
        public string FilePath { get; set; }

        [Column("BRAND_ID")]
        public int BrandId { get; set; }

        [Column("MAIN_FABRIC")]
        public string MainFabric { get; set; }
        public virtual List<ColorSettingModel> Colors { get; set; }
        public virtual List<StyleProcessModel> StyleProcesses { get; set; }
       // public virtual List<StyleFabricModel> StyleFabricProcess { get; set; }
        public virtual List<StylePartInfo> StylePartInfos { get; set; }

        [Column("TARGET_FOB")]
        public double TargetFOB { get; set; }

        [Column("GMT_ITEM_ID")]
        public int GmtItemId { get; set; }

        [Column("BUYER_DEPARTMENT_ID")]
        public int BuyerDepartmentId { get; set; }

        [Column("SIZE_RANGE_ID")]
        public int SizeRangeId { get; set; }

        [Column("STATUS")]
        public string Status { get; set; }

        [Column("REF_STYLE_ID")]
        public int RefStyleId { get; set; }

        [Column("COLOR_TYPE")]
        public string ColorType { get; set; }

        [Column("NO_OF_COLOR")]
        public int NoOfColor { get; set; }
        [Column("SEASON_ID")]
        public int SeasonId { get; set; }
        
        [Column("COLOR_LOT")]
        public string ColorLot { get; set; }
        [Column("CAD_DATE")]
        public DateTime CadFactoryDate { get; set; }
        public int YearId { get; set; }
        public string UpdateFrom { get; set; }
        [NotMapped]
        public string IsMarkerSample { get; set; }
        [NotMapped]
        public int SampleTypeId { get; set; }
        [NotMapped]
        public string IeNotification { get; set; }
        [NotMapped]
        public string CCadNotification { get; set; }
        [NotMapped]
        public string CConsNotification { get; set; }
        [NotMapped]
        public string OCostingNotification { get; set; }
        [NotMapped]
        public string CuttingCadNotification { get; set; }
        [NotMapped]
        public string BConsNotification { get; set; }
        [NotMapped]
        public string TConsNotification { get; set; }


    }

    [Table("M_STYLE_PROCESS")]
    public class StyleProcessModel : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        //[Column("STYLE_SETTING_ID")]
        //public int StyleSettingId { get; set; }
        //public virtual StyleSettingModel StyleSetting { get; set; }
        [Column("STYLE_PART_INFO_ID")]
        public int StylePartInfoId { get; set; }
        public virtual StylePartInfo StylePartInfo { get; set; }

        [Column("ITEM_ID")]
        public int ItemId { get; set; }

        [Column("CATEGORY_ID")]
        public int CategoryId { get; set; }

        [Column("INSTRUCTION")]
        public string Instruction { get; set; }
        [Column("STYLE_PART_INFO_ID")]
        public int StylePartId { get; set; }
        public virtual StylePartInfo StylePart { get; set; }
        [Column("REMARKS")]
        public string Remarks { get; set; }
        [NotMapped]
       public List<IFormFile> FileMe { get; set; }

    }
    [Table("M_STYLE_FABRIC_HEAD")]
    public class StyleFabricHead : AuditableEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CATEGORY_NAME")]
        public string CategoryName { get; set; }
        [Column("HEAD_NAME")]
        public string HeadName { get; set; }
    }

    [Table("M_STYLE_FABRIC")]
    public class StyleFabricModel : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        [Column("STYLE_PART_ID")]
        public int StylePartId { get; set; }
        public virtual StylePartInfo StylePartInfo { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [NotMapped]
        public decimal FabricWidth { get; set; }
        [NotMapped]
        public string Unit { get; set; }
        [NotMapped]
        public string ShrinkagePercentage { get; set; }
        [NotMapped]
        public decimal TargetConsumption { get; set; }
        public string UpdateFrom { get; set; }
        public string Placement { get; set; }
        public decimal CadConsumption { get; set; }
        public decimal CuttableWidthInch { get; set; }
        public decimal WashShrinkagePercentage { get; set; }
        public decimal StampShrinkagePercentage { get; set; }
        public decimal MarkerLength { get; set; }
        public decimal RatioTotal { get; set; }
        public decimal MarkerEfficiency { get; set; }
        [NotMapped]
        public decimal ItemId { get; set; }
        [NotMapped]
        public decimal FabricWidthInch { get; set; }
        [NotMapped]
        public decimal MarkerWidthInch { get; set; }
        [NotMapped]
        public int BookingCadMasterId { get; set; }
        [NotMapped]
        public string Color { get; set; }
        [NotMapped]
        public string CallFor { get; set; }
        [NotMapped]
        public string FabricComment { get; set; }
        [NotMapped]
        public decimal DesignRepeatation { get; set; }
        [NotMapped]
        public string FabricWayDirection { get; set; }
        [NotMapped]
        public decimal RequiredConsumption { get; set; }
        [NotMapped]
        public string CheckOrWay { get; set; }
    }

    [Table("M_STYLE_PART_SETUP")]
    public class StylePartSetup : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        [Column("PART_NAME")]
        public string PartName { get; set; }
        [Column("REMARKS")]
        public string Remarks { get; set; }

    }

    [Table("M_STYLE_PART_INFO")]
    public class StylePartInfo : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }
        [Column("STYLE_SETTING_ID")]
        public int StyleSettingId { get; set; }
        public virtual StyleSettingModel StyleSetting { get; set; }
        [Column("STYLE_PART_SETUP_ID")]
        public int StylePartSetupId { get; set; }
        public virtual StylePartSetup StylePartSetup { get; set; }
        [Column("REMARKS")]
        public string Remarks { get; set; }
        public string UpdateFrom { get; set; }
        [NotMapped]
        public string CallFor { get; set; } 
        [NotMapped]
        public int OldPartId { get; set; }
        [NotMapped]
        public int PreStyleId { get; set; }

    }

    [Table("M_COLOR_SETTING")]
    public class ColorSettingModel : AuditableEntity
    {
        [Column("COLOR_ID")]
        [Key]
        public int ColorId { get; set; }

        [Column("FG_MODEL")]
        public string FgModel { get; set; }

        [Column("COLOR_NAME")]
        public string ColorName { get; set; }

        [Column("BUYER_ID")]
        public int BuyerId { get; set; }

        [Column("STYLE_SETTING_ID")]
        public int StyleSettingId { get; set; }
        public virtual StyleSettingModel StyleSetting { get; set; }
    }

    [Table("M_FILE_OBJECT")]
    public class FileObjectModel : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
        [Column("KEY")]
        public string Key { get; set; }
        [Column("REF_TABLE")]
        public string RefTable { get; set; }
        [Column("HEADER")]
        public string Header { get; set; }
        [Column("REMARKS")]
        public string Remarks { get; set; }

        //public virtual List<FileModel> Files { get; set; }
    }

    [Table("M_FILE")]
    public class FileModel : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }


        [Column("FILE_OBJECT_ID")]
        public int FileObjectId { get; set; }
        public virtual FileObjectModel FileObject { get; set; }

        [Column("REF_ID")]
        public int RefId { get; set; }
        [Column("FILE_TYPE")]
        public string FileType { get; set; }
        [Column("FILE_SIZE")]
        public long FileSize { get; set; }
        [Column("LOCATION")]
        public string Location { get; set; }
        [Column("DOC_TITLE")]
        public string DocTitle { get; set; }
        [Column("VERSION")]
        public int Version { get; set; }
        [Column("ACTIVE_STATUS")]
        public string ActiveStatus { get; set; }
        [Column("OWNER")]
        public string Owner { get; set; }

        [Column("FILE_COMMENT")]
        public string FileComment { get; set; }
        [Column("FILE_NAME")]
        public string FileName { get; set; }

        [Column("UPLOAD_DATE")]
        public DateTime UploadDate { get; set; }
        [NotMapped]
        public string FileRevised { get; set; }
        public int StyleFabricId { get; set; } = 0;
        [NotMapped]
        public List<IFormFile> FormFile { get; set; }

        public string FileTypeId { get; set; }
        public int MasterId { get; set; }
         

        


    }

    [Table("L_GMT_ITEMS")]
    public class gmtitemsModel : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("GMT_NAME")]
        public string GmtName { get; set; }

        [Column("REMARKS")]
        public string Remarks { get; set; }
    }


    

    [Table("M_STYLE_SIZE")]
    public class StyleSizeRatioModel : AuditableEntity
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("SIZE_NAME")]
        public string SizeName { get; set; }

        [Column("SIZE2")]
        public string Size2 { get; set; }

        [Column("SL")]
        public string Sl { get; set; }
        [Column("RATIO")]
        public double Ratio { get; set; }
        [Column("SIZE_RANGE_ID")]
        public int SizeRangeId { get; set; }

        [Column("STYLE_SETTING_ID")]
        public int StyleSettingId { get; set; }
        [Column("QTY")]
        public decimal Qty { get; set; }
        public string UpdateFrom { get; set; }
        [NotMapped]
        public string Size1 { get; set; }
        [NotMapped]
        public string BaseSize { get; set; }
        [NotMapped]
        public int SizeId { get; set; }
    }

    public class DescriptionModel : AuditableEntity
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
    }
    public class NotificationDepartmentDto
    {
        public string Name { get; set; }
    }

}
