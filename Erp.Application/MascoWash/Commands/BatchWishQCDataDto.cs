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
        public string BatchNo { get; set; }

        public int BuyerId { get; set; }
        public string BuyerName { get; set; }

        public int JobId { get; set; }
        public string JobName { get; set; }
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int MachineId { get; set; }
        public string MachineNo { get; set; }
        public int Priority { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int GoodGarments { get; set; }

    }
}
