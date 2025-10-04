using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IGaritaRepository
    {
        Task<IEnumerable<GaritaEntity>> GetAllAsync();
        Task<GaritaEntity> GetByIdAsync(long id);
        Task<bool> ExistsAsync(long id, string name, string ruc);
        Task AddAsync(GaritaEntity entity);
        Task UpdateAsync(GaritaEntity entity);
        Task DeleteAsync(long id);
    }
}