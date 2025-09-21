using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<ProveedorEntity>> GetAllAsync();
        Task<ProveedorEntity> GetByIdAsync(int id);
        Task AddAsync(ProveedorEntity entity);
        Task UpdateAsync(ProveedorEntity entity);
        Task DeleteAsync(int id);
    }
}