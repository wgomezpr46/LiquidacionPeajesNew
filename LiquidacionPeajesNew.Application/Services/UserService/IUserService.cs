using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.UserService
{
    public interface IUserService
    {
        Task<ApiResponse<UsuarioLoginResponse>> GetByIdAsync(string code);
    }
}