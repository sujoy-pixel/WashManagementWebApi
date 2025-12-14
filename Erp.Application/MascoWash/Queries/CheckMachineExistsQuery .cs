using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    using MediatR;

    public class CheckMachineExistsQuery : IRequest<int>
    {
        public int UnitId { get; }
        public int OperationId { get; }
        public string MachineName { get; }

        public CheckMachineExistsQuery(int unitId, int operationId, string machineName)
        {
            UnitId = unitId;
            OperationId = operationId;
            MachineName = machineName;
        }
    }

}
