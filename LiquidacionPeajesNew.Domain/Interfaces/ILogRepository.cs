using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task SaveAsync(ErrorLogEntity log);
    }
}