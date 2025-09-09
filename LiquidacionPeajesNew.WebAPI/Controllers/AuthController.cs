using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _tokenService.Login(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Renueva un token JWT si ha expirado recientemente (máx. 10 minutos).
        /// </summary>
        /// <param name="request">Contiene el token expirado y los datos del usuario.</param>
        /// <returns>200 OK con el nuevo token si fue renovado, o el original si aún es válido.</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromBody] TokenRequest request)
        {
            var response = _tokenService.ValidateToken(request);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}