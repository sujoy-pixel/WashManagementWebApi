using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    public class GetDataBySearchForEdit
         : IRequest<List<TrackingNoWiseReceiveDto>>
    {
        public int UnitId { get; }
        public string ReceiveNo { get; }
        public string FromDate { get; }
        public string ToDate { get; }

        public GetDataBySearchForEdit(int unitId, string receiveNo, string fromDate, string toDate)
        {
            UnitId = unitId;
            ReceiveNo = receiveNo;
            FromDate = fromDate;  
            ToDate = toDate;

        }
    }
}
