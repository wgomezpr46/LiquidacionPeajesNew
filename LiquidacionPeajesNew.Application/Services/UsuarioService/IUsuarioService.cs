using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<ApiResponse<UsuarioLoginResponse>> GetByIdAsync(string code);
    }
}