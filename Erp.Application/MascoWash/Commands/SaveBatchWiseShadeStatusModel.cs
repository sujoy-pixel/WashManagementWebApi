


using System;
using System.Collections.Generic;
using MediatR;


using MediatR;

public class SaveBatchWiseShadeStatusModel : IRequest<WrapperResponseDatas>
{
    public int UnitId { get; set; }
    public string BatchNo { get; set; }
    public int BuyerId { get; set; }
    public decimal Weight { get; set; }
    public int Shade { get; set; }
    public string CreatedBy { get; set; }
}
