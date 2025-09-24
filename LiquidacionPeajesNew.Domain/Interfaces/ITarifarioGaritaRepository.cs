using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface ITarifarioGaritaRepository
    {
        Task<IEnumerable<TarifarioGaritaEntity>> GetAllAsync();
        Task<TarifarioGaritaEntity> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id, long idGarita, int ejeVehiculo);
        Task AddAsync(TarifarioGaritaEntity entity);
        Task UpdateAsync(TarifarioGaritaEntity entity);
        Task DeleteAsync(int id);
    }
}