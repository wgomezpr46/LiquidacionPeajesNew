using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;
using LiquidacionPeajesNew.Infrastructure.Persistence.Context;

namespace LiquidacionPeajesNew.Infrastructure.Persistence.Repositories
{
    internal class LogRepository : ILogRepository
    {
        private readonly BDALMContext _context;

        public LogRepository(BDALMContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(ErrorLogEntity log)
        {
            await _context.ErrorLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}