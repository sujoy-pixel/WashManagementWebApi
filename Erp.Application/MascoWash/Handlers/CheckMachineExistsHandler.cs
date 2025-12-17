
using Erp.Application.MascoWash.Queries;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Erp.Application.MascoWash.Handlers
{

    public class CheckMachineExistsHandler: IRequestHandler<CheckMachineExistsQuery, int>
    {
        private readonly ISaveDataList _setupService;

        public CheckMachineExistsHandler(ISaveDataList setupService)
        {
            _setupService = setupService;
        }

        public async Task<int> Handle( CheckMachineExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _setupService.CheckMachineExists(
                request.UnitId,
                request.OperationId,
                request.MachineName
            );

            return result.FirstOrDefault()?.ExistsFlag ?? 0;
        }
    }


}

