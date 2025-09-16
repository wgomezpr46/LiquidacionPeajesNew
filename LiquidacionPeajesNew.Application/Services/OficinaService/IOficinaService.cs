using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.OficinaService
{
    public interface IOficinaService
    {
        Task<ApiResponse<ICollection<OficinaResponse>>> GetAllAsync(string OfiCodigo);
    }
}