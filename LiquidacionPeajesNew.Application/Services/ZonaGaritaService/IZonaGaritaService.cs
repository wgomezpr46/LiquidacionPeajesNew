using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.ZonaGaritaService
{
    public interface IZonaGaritaService
    {
        Task<ApiResponse<IEnumerable<ZonaGaritaResponse>>> GetAllAsync();
        Task<ApiResponse<ZonaGaritaResponse>> GetByIdAsync(short id);
        Task<ApiResponse<short>> AddAsync(ZonaGaritaRequest request);
        Task<ApiResponse<short>> UpdateAsync(ZonaGaritaRequest request);
        Task<ApiResponse<short>> DeleteAsync(short id);
    }
}