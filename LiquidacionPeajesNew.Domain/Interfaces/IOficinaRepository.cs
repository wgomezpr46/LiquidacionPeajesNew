using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IOficinaRepository
    {
        Task<IEnumerable<OficinaEntity>> GetAllAsync(string OfiCodigo);
    }
}