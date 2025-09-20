using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.ZonaGaritaService
{
    public interface IZonaGaritaService
    {
        Task<ApiResponse<IEnumerable<ZonaGaritaResponse>>> GetAllAsync();
    }
}