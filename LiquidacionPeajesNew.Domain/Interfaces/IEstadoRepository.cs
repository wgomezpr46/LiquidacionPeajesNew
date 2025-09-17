using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface IEstadoRepository
    {
        Task<ICollection<EstadoEntity>> GetAllAsync();
    }
}