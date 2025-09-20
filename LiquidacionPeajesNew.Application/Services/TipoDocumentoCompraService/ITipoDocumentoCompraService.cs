using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.TipoDocumentoCompraService
{
    public interface ITipoDocumentoCompraService
    {
        Task<ApiResponse<IEnumerable<TipoDocumentoCompraResponse>>> GetAllAsync();
    }
}