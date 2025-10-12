using LiquidacionPeajesNew.Application.Services.UsuarioService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        /// Obtiene los detalles de un usuario por su código de usuario.
        /// </summary>
        /// <param name="codigo">Código del usuario.</param>
        /// <returns>Detalles del usuario solicitado.</returns>
        /// <response code="200">Retorna los detalles del usuario con éxito.</response>
        /// <response code="400">No se pudo encontrar el usuario con el código proporcionado.</response>
        /// GET: api/Usuario/GetById/0001
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetById(string codigo)
        {
            var response = await _service.GetByIdAsync(codigo);
            return Ok(response);
        }
    }
}