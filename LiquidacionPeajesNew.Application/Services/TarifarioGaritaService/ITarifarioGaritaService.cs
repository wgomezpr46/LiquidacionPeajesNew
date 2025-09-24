using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.TarifarioGaritaService
{
    public interface ITarifarioGaritaService
    {
        Task<ApiResponse<IEnumerable<TarifarioGaritaResponse>>> GetAllAsync();
        Task<ApiResponse<TarifarioGaritaResponse>> GetByIdAsync(int id);
        Task<ApiResponse<int>> AddAsync(TarifarioGaritaRequest request);
        Task<ApiResponse<int>> UpdateAsync(TarifarioGaritaRequest request);
        Task<ApiResponse<int>> DeleteAsync(int id);
    }
}