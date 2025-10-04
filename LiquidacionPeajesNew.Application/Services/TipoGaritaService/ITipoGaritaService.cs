using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.TipoGaritaService
{
    public interface ITipoGaritaService
    {
        Task<ApiResponse<IEnumerable<TipoGaritaResponse>>> GetAllAsync();
        Task<ApiResponse<TipoGaritaResponse>> GetByIdAsync(short id);
        Task<ApiResponse<int>> AddAsync(TipoGaritaRequest request);
        Task<ApiResponse<int>> UpdateAsync(TipoGaritaRequest request);
        Task<ApiResponse<int>> DeleteAsync(short id);
    }
}