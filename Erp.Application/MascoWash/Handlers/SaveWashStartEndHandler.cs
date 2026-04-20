

using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Setup.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


public class SaveWashStartEndHandler
    : IRequestHandler<SaveWashStartEndModel, WrapperResponseData>
{
    private readonly ISaveDataList _setupservice;

    public SaveWashStartEndHandler(ISaveDataList setupservice)
    {
        _setupservice = setupservice;
    }

    public async Task<WrapperResponseData> Handle(
        SaveWashStartEndModel request,
        CancellationToken cancellationToken)
    {
        return await _setupservice.SaveWashStartEndService(request);
    }
}