using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class SaveBatchWiseShadeStatusDataHandler
    : IRequestHandler<SaveBatchWiseShadeStatusModel, WrapperResponseDatas>
{
    private readonly ISaveDataList _setupservice;

    public SaveBatchWiseShadeStatusDataHandler(ISaveDataList setupservice)
    {
        _setupservice = setupservice;
    }

    public async Task<WrapperResponseDatas> Handle(
        SaveBatchWiseShadeStatusModel request,
        CancellationToken cancellationToken)
    {
        return await _setupservice.SaveBatchWiseShadeStatusService(request);
    }
}