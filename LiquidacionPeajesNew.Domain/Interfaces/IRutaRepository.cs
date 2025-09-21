using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IRutaRepository
    {
        Task<IEnumerable<RutaEntity>> GetAllAsync();
        Task<RutaEntity> GetByIdAsync(int id);
        Task<RutaEntity> GetByOrigenDestinoAsync(int id, string IdOrigen, string IdDestino);
        Task AddAsync(RutaEntity entity);
        Task UpdateAsync(RutaEntity entity);
        Task DeleteAsync(int id);
    }
}