using System;
using System.Collections.Generic;
using MediatR;

public class SaveWashStartEndModel : IRequest<WrapperResponseData>
{
    public List<WashStartEndRow> Rows { get; set; }
}


public class WashStartEndRow
{
    public int UnitId { get; set; }
    public int BuyerId { get; set; }
    public string BatchNo { get; set; }

    // 🔥 CHANGE HERE
    public string ProcessId { get; set; }   // "1,2,3"
    public string MachineId { get; set; }   // "4,5,6"

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }


    //[JsonConverter(typeof(TimeSpanJsonConverter))]
    public string StartTime { get; set; }
    public decimal Weight { get; set; }

    //[JsonConverter(typeof(TimeSpanJsonConverter))]
    public string EndTime { get; set; }
    public string CreatedBy { get; set; }
}

public class WrapperResponseData
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public List<WashStartEndResponseDto> Data { get; set; }
}
public class WrapperResponseDatas
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public object Data { get; set; }
}

// Same class used by QueryFirstOrDefaultAsync
public class AcidWashBatchPrepareDbResponse
{
    public int ResultCode { get; set; }
    public string AcidBatchNo { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Message { get; set; }
}

public class WashStartEndResponseDto
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public int BuyerId { get; set; }
    public string BatchNo { get; set; }

    public string ProcessId { get; set; }
    public string MachineId { get; set; }

    public DateTime? StartDate { get; set; }
    public string StartTime { get; set; }

    public DateTime? EndDate { get; set; }
    public string EndTime { get; set; }

    public string Operation { get; set; }
    public string CreatedBy { get; set; }
    public decimal Weight { get; set; }

    public DateTime CreatedDate { get; set; }

    public string MachineNames { get; set; }
    public string ProcessNames { get; set; }
}