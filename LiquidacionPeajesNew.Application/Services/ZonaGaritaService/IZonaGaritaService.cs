using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.ZonaGaritaService
{
    public interface IZonaGaritaService
    {
        Task<ApiResponse<IEnumerable<ZonaGaritaResponse>>> GetAllAsync();
        Task<ApiResponse<ZonaGaritaResponse>> GetByIdAsync(byte id);
        Task<ApiResponse<int>> AddAsync(ZonaGaritaRequest request);
        Task<ApiResponse<int>> UpdateAsync(ZonaGaritaRequest request);
        Task<ApiResponse<int>> DeleteAsync(byte id);
    }
}