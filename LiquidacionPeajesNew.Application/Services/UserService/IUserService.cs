using LiquidacionPeajesNew.Application.DTOs.Responses;

namespace LiquidacionPeajesNew.Application.Services.UserService
{
    public interface IUserService
    {
        Task<ApiResponse<IEnumerable<UserResponse>>> GetAllAsync();
        Task<ApiResponse<UserResponse>> GetByIdAsync(short id);
    }
}