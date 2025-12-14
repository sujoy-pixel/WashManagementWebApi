using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.MascoWash.Queries
{
    using Erp.Application.MascoWash.Commands;
    using MediatR;
    using System.Collections.Generic;

    public class GetMachineMasterListQuery : IRequest<List<MachineMasterDetailModel>>
    {
        // No input parameters needed for this query
    }

}
