using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IModoPagoGaritaRepository
    {
        Task<IEnumerable<ModoPagoGaritaEntity>> GetAllAsync();
        Task<ModoPagoGaritaEntity> GetByIdAsync(short id);
        Task<bool> ExistsAsync(short id, string name);
        Task AddAsync(ModoPagoGaritaEntity entity);
        Task UpdateAsync(ModoPagoGaritaEntity entity);
        Task DeleteAsync(short id);
    }
}