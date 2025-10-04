using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.OficinaService
{
    public interface IOficinaService
    {
        Task<ApiResponse<IEnumerable<OficinaResponse>>> GetAllAsync(string OfiCodigo);
    }
}