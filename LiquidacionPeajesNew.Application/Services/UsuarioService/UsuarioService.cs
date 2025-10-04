using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Application.Services.TokenService;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, ITokenService tokenService, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UsuarioLoginResponse>> GetByIdAsync(string codigo)
        {
            var user = await _repository.GetByIdAsync(codigo);
            var response = _mapper.Map<UsuarioLoginResponse>(user);

            return new ApiResponse<UsuarioLoginResponse>(true, response, AppResponseCode.AuthenticationSuccessful);
        }
    }
}