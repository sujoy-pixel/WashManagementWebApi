

//using MediatR;
//using System;
//using System.Collections.Generic;

//public class DateWiseRejectionResponseDto
//{
//    public DateTime? Date { get; set; }

//    public string TrackingNo { get; set; }

//    public string ReceiveFrom { get; set; }

//    public string Buyer { get; set; }

//    public string Job { get; set; }

//    public string Order { get; set; }

//    public string Style { get; set; }

//    public string Color { get; set; }

//    public string DressPart { get; set; }

//    public string WashCategory { get; set; }

//    public string ItemName { get; set; }

//    public string Shift { get; set; }

//    public string QCName { get; set; }

//    public decimal? ReceiveQty { get; set; }

//    public string UoM { get; set; }

//    public string BatchNo { get; set; }

//    public int? TotalCheckQty { get; set; }



//    public int? TotalRejectQty { get; set; }

//    public string RejectPercent { get; set; }

//    public Dictionary<string, int> SizeRejects { get; set; }
//          = new Dictionary<string, int>();

//}

using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

public class DateWiseRejectionResponseDto
{
    public DateTime? Date { get; set; }

    public string TrackingNo { get; set; }
    public string ReceiveFrom { get; set; }
    public string Buyer { get; set; }
    public string Job { get; set; }
    public string Order { get; set; }
    public string Style { get; set; }
    public string Color { get; set; }
    public string DressPart { get; set; }
    public string WashCategory { get; set; }
    public string ItemName { get; set; }
    public string Shift { get; set; }
    public string QCName { get; set; }

    public decimal? ReceiveQty { get; set; }

    public string UoM { get; set; }
    public string BatchNo { get; set; }

    public int? TotalCheckQty { get; set; }
    public int? TotalRejectQty { get; set; }

    public string RejectPercent { get; set; }

    public Dictionary<string, int> SizeRejects { get; set; }
        = new Dictionary<string, int>();
}
