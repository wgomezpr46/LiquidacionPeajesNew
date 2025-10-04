using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.TokenService
{
    public interface ITokenService
    {
        Task<ApiResponse<TokenResponse>> Login(LoginRequest request);
        Task<ApiResponse<TokenResponse>> ValidateToken(TokenRequest request);
        ApiResponse<string> GenerateToken(UsuarioLoginRequest request);
    }
}