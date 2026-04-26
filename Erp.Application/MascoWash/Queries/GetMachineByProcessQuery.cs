
using MediatR;
using System.Collections.Generic;

namespace Erp.Application.MascoWash.Queries
{
    // Request
    public class GetMachineByProcessQuery : IRequest<List<GetMachineByProcessDto>>
    {
        public string ProcessIds { get; set; }   // Example: "1,2,3"
    }

    // Response DTO
    public class GetMachineByProcessDto
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
    }
}