using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.Services.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _service;

        public AuthController(ITokenService service)
        {
            _service = service;
        }

        /// <summary>
        /// Autentica a un usuario con las credenciales proporcionadas y genera un token JWT si son válidas.
        /// </summary>
        /// <param name="request">Objeto que contiene las credenciales del usuario (usuario y contraseña).</param>
        /// <returns>
        /// Retorna un código 200 (OK) con el token de acceso si la autenticación es exitosa; 
        /// de lo contrario, retorna un código 400 (Bad Request) con un mensaje de error.
        /// </returns>
        /// <response code="200">Retorna el token de acceso con éxito.</response>
        /// <response code="400">Las credenciales proporcionadas no son válidas.</response>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _service.Login(request);
            return Ok(response);
        }

        /// <summary>
        /// Renueva un token JWT si ha expirado recientemente (máx. 10 minutos).
        /// </summary>
        /// <param name="request">Contiene el token expirado y los datos del usuario.</param>
        /// <returns>200 OK con el nuevo token si fue renovado, o el original si aún es válido.</returns>
        /// <response code="200">Retorna un nuevo token si el token original ha sido renovado.</response>
        /// <response code="400">El token proporcionado es inválido o no puede ser renovado.</response>
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var response = await _service.ValidateToken(request);
            return Ok(response);
        }
    }
}