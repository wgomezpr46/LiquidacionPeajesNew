using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Domain.Interfaces
{
    public interface ITipoDocumentoCompraRepository
    {
        Task<IEnumerable<TipoDocumentoCompraEntity>> GetAllAsync();
    }
}