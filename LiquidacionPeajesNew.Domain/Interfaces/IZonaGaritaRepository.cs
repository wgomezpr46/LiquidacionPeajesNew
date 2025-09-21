using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IZonaGaritaRepository
    {
        Task<IEnumerable<ZonaGaritaEntity>> GetAllAsync();
        Task<ZonaGaritaEntity> GetByIdAsync(byte id);
        Task AddAsync(ZonaGaritaEntity entity);
        Task UpdateAsync(ZonaGaritaEntity entity);
        Task DeleteAsync(byte id);
    }
}