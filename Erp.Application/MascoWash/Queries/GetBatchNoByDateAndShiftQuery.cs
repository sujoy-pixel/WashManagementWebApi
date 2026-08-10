using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
 

    public class GetBatchNoByDateAndShiftQuery
    : IRequest<List<GetBatchNoByDateAndShiftDto>>
    {
        public DateTime Date { get; set; }

        public int ShiftId { get; set; }
    }

    public class GetBatchNoByDateAndShiftDto
    {
        public int MasterId { get; set; }

        public string BatchNo { get; set; }
    }
}