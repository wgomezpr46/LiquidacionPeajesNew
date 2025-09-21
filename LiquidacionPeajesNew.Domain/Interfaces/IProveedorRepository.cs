using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<ProveedorEntity>> GetAllAsync();
        Task<ProveedorEntity> GetByIdAsync(int id);
        Task<ProveedorEntity> GetByRUCAsync(int id, string ruc);
        Task AddAsync(ProveedorEntity entity);
        Task UpdateAsync(ProveedorEntity entity);
        Task DeleteAsync(int id);
    }
}