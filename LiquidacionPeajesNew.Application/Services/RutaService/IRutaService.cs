using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.RutaService
{
    public interface IRutaService
    {
        Task<ApiResponse<IEnumerable<RutaResponse>>> GetAllAsync();
        Task<ApiResponse<RutaResponse>> GetByIdAsync(int id);
        Task<ApiResponse<int>> AddAsync(RutaRequest request);
        Task<ApiResponse<int>> UpdateAsync(RutaRequest request);
        Task<ApiResponse<int>> DeleteAsync(int id);
    }
}