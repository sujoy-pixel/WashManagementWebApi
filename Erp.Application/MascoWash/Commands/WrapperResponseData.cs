// =============================================
// File: Commands/SaveWashStartEndModel.cs
// =============================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Erp.Application.MascoWash.Commands
{
    public class SaveWashStartEndModel : IRequest<WrapperResponseDatas>
    {
        [Required]
        public List<WashStartEndRow> Rows { get; set; } = new List<WashStartEndRow>();
    }

    public class WashStartEndRow
    {
        public int UnitId { get; set; }
        public int BuyerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BatchNo { get; set; }
        public string ProcessId { get; set; }
        public string MachineId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string CreatedBy { get; set; }
    }

    public class WashStartEndResultRow
    {
        public int? Id { get; set; }
        public int? UnitId { get; set; }
        public int? BuyerId { get; set; }
        public string BatchNo { get; set; }
        public string ProcessId { get; set; }
        public string MachineId { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string EndTime { get; set; }
        public string Operation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string MachineNames { get; set; }
        public string ProcessNames { get; set; }
    }

    public class WrapperResponseDatas
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<WashStartEndResultRow> DataRows { get; set; }
            = new List<WashStartEndResultRow>();
    }
}