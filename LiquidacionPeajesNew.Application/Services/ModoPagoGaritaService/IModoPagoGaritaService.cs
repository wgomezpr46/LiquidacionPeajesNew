using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.ModoPagoGaritaService
{
    public interface IModoPagoGaritaService
    {
        Task<ApiResponse<IEnumerable<ModoPagoGaritaResponse>>> GetAllAsync();
        Task<ApiResponse<ModoPagoGaritaResponse>> GetByIdAsync(short id);
        Task<ApiResponse<int>> AddAsync(ModoPagoGaritaRequest request);
        Task<ApiResponse<int>> UpdateAsync(ModoPagoGaritaRequest request);
        Task<ApiResponse<int>> DeleteAsync(short id);
    }
}