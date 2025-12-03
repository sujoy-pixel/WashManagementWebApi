using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class UnitNameGet : IRequest<List<DropdownListDto1>>
    {
    }

    public class UnitNameGetList
    {
        public int UnitId { get; set; }
        public string UnitEName { get; set; }
    }

    public class DropdownListDto1
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
}
