using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.TokenService
{
    public interface ITokenService
    {
        Task<ApiResponse<TokenResponse>> Login(string name, string password);
        ApiResponse<string> GenerateToken(UserRequest request);
        ApiResponse<TokenResponse> ValidateToken(TokenRequest request);
    }
}