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

        public async Task<ApiResponse<IEnumerable<UserResponse>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<UserResponse>>(users);

            return new ApiResponse<IEnumerable<UserResponse>>(true, response, AppResponseCode.AuthenticationSuccessful);
        }

        public async Task<ApiResponse<UserResponse>> GetByIdAsync(short id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var response = _mapper.Map<UserResponse>(user);

            return new ApiResponse<UserResponse>(true, response, AppResponseCode.AuthenticationSuccessful);
        }
    }
}