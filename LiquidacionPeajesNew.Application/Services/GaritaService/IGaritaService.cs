using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.GaritaService
{
    public interface IGaritaService
    {
        Task<ApiResponse<IEnumerable<GaritaResponse>>> GetAllAsync();
        Task<ApiResponse<GaritaResponse>> GetByIdAsync(long id);
        Task<ApiResponse<long>> AddAsync(GaritaRequest request);
        Task<ApiResponse<long>> UpdateAsync(GaritaRequest request);
        Task<ApiResponse<long>> DeleteAsync(long id);
    }
}