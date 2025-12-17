using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class FaultWiseValueTagGet : IRequest<List<FaultWiseValueTagDetailGetAll>>
    {
    }
    public class FaultWiseValueTagGetList
    {
        public int FaultWiseMasterId { get; set; }
        public string Type { get; set; }
        public int InspectionHeadId { get; set; }
        public int FaultHeadId { get; set; }

        public List<FaultWiseValueTagDetailGetList> FaultWiseDetails { get; set; }
    }
    public class FaultWiseValueTagDetailGetList
    {
        public int FaultWiseDetailsId { get; set; }
        public int FaultWiseMasterId { get; set; }
        public int FaultNameId { get; set; }
        public decimal Value { get; set; }
        public bool IsChecked { get; set; }
    }

    public class FaultWiseValueTagDetailGetAll
    {
        public int FaultWiseMasterId { get; set; }
        public string Type { get; set; }
        public int InspectionHeadId { get; set; }
        public int FaultHeadId { get; set; }
        public int FaultWiseDetailsId { get; set; }
        public int FaultNameId { get; set; }
        public decimal Value { get; set; }
        public bool IsChecked { get; set; }
    }
}
