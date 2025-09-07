using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Application.Services.TokenService;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<UserResponse>>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            var response = users.Select(u => new UserResponse
            {
                Usr_Codigo = u.IdUsuario,
                Usr_Nombre = u.Usuario,
                Usr_Estado = u.Estado
            });

            return new ApiResponse<IEnumerable<UserResponse>>(true, response, AppResponseCode.AuthenticationSuccessful);
        }

        public async Task<ApiResponse<UserResponse>> GetByIdAsync(short id)
        {
            var user = await _repository.GetByIdAsync(id);
            var response = new UserResponse
            {
                Usr_Codigo = user.IdUsuario,
                Usr_Nombre = user.Usuario,
                Usr_Estado = user.Estado
            };

            return new ApiResponse<UserResponse>(true, response, AppResponseCode.AuthenticationSuccessful);
        }
    }
}