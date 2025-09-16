using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IRutaRepository
    {
        Task<IEnumerable<RutaEntity>> GetAllAsync();
        Task<RutaEntity> GetByIdAsync(int id);
        Task AddAsync(RutaEntity ruta);
        Task UpdateAsync(RutaEntity ruta);
        Task DeleteAsync(int id);
    }
}