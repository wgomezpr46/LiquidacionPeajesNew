using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface ITipoGaritaRepository
    {
        Task<IEnumerable<TipoGaritaEntity>> GetAllAsync();
        Task<TipoGaritaEntity> GetByIdAsync(short id);
        Task<bool> ExistsAsync(short id, string name);
        Task AddAsync(TipoGaritaEntity entity);
        Task UpdateAsync(TipoGaritaEntity entity);
        Task DeleteAsync(short id);
    }
}