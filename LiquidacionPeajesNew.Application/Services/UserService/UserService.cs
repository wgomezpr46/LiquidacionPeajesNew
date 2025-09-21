using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Application.Services.TokenService;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UsuarioLoginResponse>> GetByIdAsync(string code)
        {
            var user = await _userRepository.GetByIdAsync(code);
            var response = _mapper.Map<UsuarioLoginResponse>(user);

            return new ApiResponse<UsuarioLoginResponse>(true, response, AppResponseCode.AuthenticationSuccessful);
        }
    }
}