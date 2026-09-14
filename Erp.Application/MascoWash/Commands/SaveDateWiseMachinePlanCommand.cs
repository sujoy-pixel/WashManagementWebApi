using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Commands
{
    /// <summary>
    /// Save body for Setup/SaveDateWiseMachinePlan. Mirrors sp_SaveWashDateWiseMachinePlan's
    /// three table-valued parameters (@PlanData / @ProcessData / @MachineData), correlated by
    /// RowGuid - each PlanData line's RowGuid is the key its ProcessData/MachineData rows join
    /// back to inside the SP (via the @InsertedMap OUTPUT table). UnitId/CreatedBy are scalar
    /// params on the SP, not TVP columns, so they live once at the top level here, not per line.
    /// </summary>
    public class SaveDateWiseMachinePlanCommand : IRequest<Result>
    {
        public int UnitId { get; set; }
        public List<MachinePlanLineDto> PlanData { get; set; } = new();
        public List<MachinePlanProcessLineDto> ProcessData { get; set; } = new();
        public List<MachinePlanMachineLineDto> MachineData { get; set; } = new();
    }

    public class MachinePlanLineDto
    {
        public Guid RowGuid { get; set; }
        public int OrderDetailId { get; set; }
        public decimal PlanQty { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public string Remarks { get; set; }
    }

    public class MachinePlanProcessLineDto
    {
        public Guid RowGuid { get; set; }
        public int ProcessId { get; set; }
    }

    public class MachinePlanMachineLineDto
    {
        public Guid RowGuid { get; set; }
        public int MachineId { get; set; }
    }
}
