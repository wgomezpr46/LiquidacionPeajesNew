using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.ProveedorService
{
    public interface IProveedorService
    {
        Task<ApiResponse<IEnumerable<ProveedorResponse>>> GetAllAsync();
        Task<ApiResponse<RutaResponse>> GetByIdAsync(int id);
        Task<ApiResponse<int>> AddAsync(ProveedorRequest request);
        Task<ApiResponse<int>> UpdateAsync(ProveedorRequest request);
        Task<ApiResponse<int>> DeleteAsync(int id);
    }
}