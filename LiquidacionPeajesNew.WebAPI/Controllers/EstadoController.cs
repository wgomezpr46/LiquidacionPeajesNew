using LiquidacionPeajesNew.Application.Services.EstadoService;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _service;

        public EstadoController(IEstadoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene todos los estados disponibles.
        /// </summary>
        /// <returns>Lista de estados.</returns>
        /// <response code="200">Retorna la lista de estados con éxito.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// GET: api/Estado/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }
    }
}