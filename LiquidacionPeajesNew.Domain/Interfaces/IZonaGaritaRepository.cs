using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IZonaGaritaRepository
    {
        Task<IEnumerable<ZonaGaritaEntity>> GetAllAsync();
        Task<ZonaGaritaEntity> GetByIdAsync(short id);
        Task<bool> ExistsAsync(short id, string name);
        Task AddAsync(ZonaGaritaEntity entity);
        Task UpdateAsync(ZonaGaritaEntity entity);
        Task DeleteAsync(short id);
    }
}