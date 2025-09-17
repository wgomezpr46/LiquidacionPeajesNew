using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.EstadoService
{
    public interface IEstadoService
    {
        Task<ApiResponse<ICollection<EstadoResponse>>> GetAllAsync();
    }
}