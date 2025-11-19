using System.Threading;
using System.Threading.Tasks;
using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;
using Erp.Infrastructure.Persistence;

namespace Erp.Infrastructure.Services
{
    public class LogToDatabaseService : ILogToDatabaseService
    {
        private readonly IDateTime _dateTime;
        private readonly ApplicationDbContext _context;
        public LogToDatabaseService(ApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }
        //public async Task<Result> Save(RequestLoggerEntity loggerEntity, CancellationToken cancellationToken)
        //{
        //    loggerEntity.DateTime = _dateTime.Now;

        //    _context.LoggerEntities.Add(loggerEntity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Result.Success();
        //}
    }
}
