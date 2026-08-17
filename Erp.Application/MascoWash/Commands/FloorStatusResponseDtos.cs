using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Queries
{
    public class FloorStatusResponseDtos
    {
        public int? SL { get; set; }

        public string BatchNo { get; set; }

        public string Buyer { get; set; }

        public string Job { get; set; }

        public string Style { get; set; }

        public string Order { get; set; }

        public string Type { get; set; }

        public string Fabrication { get; set; }

        public string Color { get; set; }

        public string DressPart { get; set; }

        public string GSM { get; set; }

        public string ShadeBody { get; set; }

        public string ShadeFabric { get; set; }

        public decimal? FabricQtyBody { get; set; }

        public decimal? FabricQtyOther { get; set; }

        public decimal? GarmentsQty { get; set; }

        public DateTime? OperationStartDate { get; set; }

        public string OperationName { get; set; }

        public string MachineName { get; set; }

        public string OperatorName { get; set; }

        public string LoadStart { get; set; }

        public string LoadEnd { get; set; }

        public string Duration { get; set; }

        public string TotalDuration { get; set; }

        public string Status { get; set; }
    }
}