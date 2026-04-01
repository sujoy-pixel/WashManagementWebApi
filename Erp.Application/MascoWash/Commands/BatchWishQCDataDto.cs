using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Commands
{
    public class BatchWishQCDataDto

    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public int UnitId { get; set; }
        public string BuyerName { get; set; }
        public int BuyerId { get; set; }
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public int JobId { get; set; }
        public string JobNo { get; set; }

        public string Type { get; set; }
       
        public string FabricationName { get; set; }
      
        public int FabricationId { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public string DressPart { get; set; }
        public int DressPartId { get; set; }

        public string UOM { get; set; }
        public int UomId { get; set; }

        public DateTime PrepareDate { get; set; }
        public string BatchNo { get; set; }
        public int MachineId { get; set; }
        public string MachineNo { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int Priority { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int GoodGarments { get; set; }

    }
}
